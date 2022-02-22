using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour , IPoolItems
{
    private float speed = 12;
    private float damage = 100f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,10f);
    }
    void Update()
    {
        rb.MovePosition(rb.position + (transform.forward * Time.deltaTime * speed));
       
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


    void IPoolItems.ResetObj()
    {

    }

    GameObject IPoolItems.getGameObject()
    {
        return this.gameObject;
    }
}
