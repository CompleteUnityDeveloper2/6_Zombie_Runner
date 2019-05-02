using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for handling health - current, increasing, decreasing

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken", damage);
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        // TODO: do we still need to check for animator?
        Animator animator = GetComponent<Animator>();
        if(!animator) 
        {
            Debug.LogError("Looks like the thing you killed has no animator");
            return;
        }
        else
        {
            animator.SetTrigger("die");
        }
    }
}