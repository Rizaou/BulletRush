using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel : MonoBehaviour, IPoolItems
{
    [SerializeField] protected float health = 100f;
    [SerializeField] protected Transform target;
    [SerializeField] protected GameManager gameManager;
    public bool destroy = false;
    protected NavMeshAgent agent;

    //protected Rigidbody rigidbody;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").gameObject.transform;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //rigidbody = GetComponent<Rigidbody>();
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
        gameManager.EnemyDestroyed();
        Debug.Log("Destroy");
    }

    
   void IPoolItems.ResetObj()
   {

   }

   GameObject IPoolItems.getGameObject()
   {
       return  this.gameObject;
   }

}
