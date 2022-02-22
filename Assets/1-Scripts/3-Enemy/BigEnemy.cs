using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyModel
{
    
    protected override void Awake()
    {
        base.Awake();
        health = 200;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
}
