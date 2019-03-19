using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] float attackRange = 5f;
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    
    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update() {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);    
    }
}
