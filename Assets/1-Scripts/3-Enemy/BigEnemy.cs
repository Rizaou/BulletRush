using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        MoveToTarget();
    }

    public bool readyToAttack = false;
    public bool noTarget = false;
    protected override void MoveToTarget()
    {
        //base.MoveToTarget();

        // Player'ın sağına mı daha yakın yoksa soluna mı?
        // Eğer ikisine de gitmek mümkün değilse yerinde kal
        // En yakın olan yere git
        // Gittikten sonra hızını arttırıp player'a arkadan saldır.

        NavMeshPath path = new NavMeshPath();


        Vector3 player = GameManager.instance.player.transform.position;
        Vector3 left = player + Vector3.left * 5 + Vector3.back * 3;
        Vector3 right = player + Vector3.right * 5 + Vector3.back * 3;
        Vector3 back = player + Vector3.back * 3;
        Vector3 target = player;

        

        if (Vector3.Distance(transform.position, left) <= Vector3.Distance(transform.position, right) && !readyToAttack)
        {
            if (agent.CalculatePath(left, path))
            {
                target = left;
                agent.SetDestination(left);
                noTarget = false;

            }
            else
            {
                agent.SetDestination(agent.transform.position);
                noTarget = true;
            }

        }
        else
        {
            if (agent.CalculatePath(right, path))
            {
                target = right;
                agent.SetDestination(right);
                noTarget = false;
            }
            else
            {
                 agent.SetDestination(agent.transform.position);
                 noTarget = true;
            }

        }


        // if (Vector3.Distance(transform.position, back) < Vector3.Distance(transform.position, target))
        // {
        //     target = back;
        //     readyToAttack = true;
        //     target = player;
        //     agent.speed *= 2;
        // }


        if (agent.remainingDistance <= 1f && !readyToAttack && !noTarget)
        {

            readyToAttack = true;
            target = player;
            agent.speed *= 2;
            noTarget = false;
        }

        if(readyToAttack)
        {
            target = player;
        }

        agent.SetDestination(target);


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
        if (health == 0)
        {
            DestryoEnemy();
        }
    }
}
