using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyModel
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        MoveToTarget();
       
    }

    public override void DestryoEnemy()
    {
        base.DestryoEnemy();
        destroy = true;
        gameObject.SetActive(false);
        
    }

    public override void TakeDamage()
    {
        base.TakeDamage();
        if(health == 0)
        {
            DestryoEnemy();
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
