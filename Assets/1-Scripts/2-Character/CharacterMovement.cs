using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float normalSpeed = 5f;
    private float tempSpeed;
    [SerializeField] private float slowSpeed = 2f;

    private Rigidbody thisRigidbd;
    [SerializeField] private GameObject characterMesh;
    [SerializeField] private Radar radar;
    [SerializeField] private Fire fire;

    public float lookSpeed = 5f;

    float horizontal = 0;
    float vertical = 0;


    void Awake()
    {
        thisRigidbd = gameObject.GetComponent<Rigidbody>();
        tempSpeed = normalSpeed;
    }


    void FixedUpdate()
    {
        Movement();
        RotateCharacter();
    }



    private void Movement()
    {
        // Kullanıcı ekrana dokunmuyorsa fonksiyona girme
        if (!Input.GetMouseButton(0)) return;

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        Vector3 movementVector = new Vector3(horizontal, 0, vertical);
        thisRigidbd.MovePosition(thisRigidbd.position + (movementVector * tempSpeed * Time.fixedDeltaTime));

    }

    private void RotateCharacter()
    {
        Transform target = radar.GetNearestEnemy();


        if (target == null) //Hedefte düşman yoksa joystick yönüne doğru bak
        {
            StopAttack();
            tempSpeed = normalSpeed;
            Vector3 joysticValues = new Vector3(horizontal, 0, vertical);

            Quaternion lookRot = Quaternion.LookRotation((transform.position + joysticValues.normalized) - gameObject.transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, lookSpeed * 3 * Time.deltaTime);
        }
        else // Hedefte düşman varsa düşmana doğru bak ve ateş et.
        {

            Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookRot, lookSpeed * Time.deltaTime);

            if (!isAttack)
            {
                StartCoroutine(IFire());
            }


        }

    }

    private bool isAttack = false;

    private void StopAttack()
    {

        StopCoroutine(IFire());
        isAttack = false;

    }
    private IEnumerator IFire()
    {
        tempSpeed = slowSpeed;
        isAttack = true;
        while (isAttack)
        {

            fire.FireBullet();
            yield return new WaitForSeconds(.1f);
        }


        isAttack = false;

    }

}
