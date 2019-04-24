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
    // serialize?
    float turnSpeed = 5f;

    Health health;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] bool attackTarget = false;

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
    }
    
    private void Update()
    {
        if (health.IsDead()) return;
        CalculateDistance();
        CanSeeTarget();
        AttackIfProvoked();
    }

    private void CalculateDistance()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position); 
    }

    public void BeenShot()
    {
        attackTarget = true;
    }

    private void CanSeeTarget()
    {
        if (distanceToTarget <= attackRange)
        {
            attackTarget = true;
        }
    }

    private void AttackIfProvoked()
    {
        if(attackTarget == false) { return; }
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
