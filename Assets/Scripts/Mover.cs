using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// note: responsible for moving enemy, based upon navmesh and provokation

public class Mover : MonoBehaviour
{
    [SerializeField] float attackRange = 5f;
    [SerializeField] Transform target;
    [SerializeField] float turnSpeed = 5f;

    EnemyHealth health;
    NavMeshAgent navMeshAgent;

    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;  

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();  // cached because used in update
    }
    
    private void Update()
    {
        if (health.IsDead()) return;  // could disable this component
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= attackRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken(float damage)
    { 
        isProvoked = true;
    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        FaceTarget();
        // set this to false in case player moves out of range
        GetComponent<Animator>().SetBool("attack", false);
        // using a trigger for move
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        // add SFX and VFX here
    }

    private void FaceTarget()
    {
        // find the direction of the target and normalise it
        Vector3 direction = (target.position - transform.position).normalized;
        // create a new Vector3 for the look rotation and store it in variable
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // use Slerp - spherically interpolates between two vectors (link to docs)
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);    
    }
}
