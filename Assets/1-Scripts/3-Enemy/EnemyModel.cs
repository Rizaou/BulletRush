using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] protected float health = 100f;
    [SerializeField] protected Transform target;
    public bool destroy = false;
    protected NavMeshAgent agent;

    protected Rigidbody rigidbody;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        agent.SetDestination(target.position);
    }

    public virtual void TakeDamage()
    {
        health -= 100;
    }


    public virtual void DestryoEnemy()
    {
        Debug.Log("Destroy");
    }

}
