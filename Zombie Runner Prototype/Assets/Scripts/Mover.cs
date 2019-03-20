using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] float attackRange = 5f;
    [SerializeField] Transform target;
    
    float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    
    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        FaceTarget();
        MoveToAttack(distance);
    }

    private void MoveToAttack(float distance)
    {
        if (distance <= attackRange)
        {
            navMeshAgent.SetDestination(target.position);
            if (distance <= navMeshAgent.stoppingDistance)
            {
                
                //AttackTarget();
            }
        }
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
