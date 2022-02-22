using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed = 12;
    private float damage = 100f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.MovePosition(rb.position + (transform.forward * Time.deltaTime * speed));
        //transform.Translate(Vector3.forward* Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Düşmana hasar ver
            collision.gameObject.GetComponent<EnemyModel>().TakeDamage();
        }

        DestroyBullet();


    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
