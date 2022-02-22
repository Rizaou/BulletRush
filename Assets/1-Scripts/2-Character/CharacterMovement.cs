using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed = 5f;

    private Rigidbody thisRigidbd;
    [SerializeField] private GameObject characterMesh;
    [SerializeField] private Radar radar;
    public float lookSpeed = 5f;

    float horizontal = 0;
    float vertical = 0;


    void Awake()
    {
        thisRigidbd = gameObject.GetComponent<Rigidbody>();
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
        thisRigidbd.MovePosition(thisRigidbd.position + (movementVector * speed * Time.fixedDeltaTime));

    }

    private void RotateCharacter()
    {
        Transform target = radar.GetNearestEnemy();


        if (target == null) //Hedefte düşman yoksa joystick yönüne doğru bak
        {

            Vector3 joysticValues = new Vector3(horizontal, 0, vertical);

            Quaternion lookRot = Quaternion.LookRotation((transform.position + joysticValues.normalized) - gameObject.transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, lookSpeed * 3 * Time.deltaTime);
        }
        else // Hedefte düşman varsa düşmana doğru bak.
        {

            Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookRot, lookSpeed * Time.deltaTime);
        }

    }

}
