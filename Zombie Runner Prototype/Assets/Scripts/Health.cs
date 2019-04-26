using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for handling health - current, increasing, decreasing

public class Health : MonoBehaviour
{
    [SerializeField] float startingHitPoints = 100f;

    bool isDead = false;
    // exposed for debugging so we can see if we are being hit
    [SerializeField] float currentHitPoints;

    private void Start() 
    {
        currentHitPoints = startingHitPoints;    
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        currentHitPoints -= damage;
        if (currentHitPoints <= 0)
        {
            Die();
        }
    }

    // added so we can check if the player is dead or not
    public float ReturnCurrentHealth()
    {
        return currentHitPoints;
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        if (GetComponent<Enemy>())
        {        
            // comment on why protecting / checking
            // create variable and only get once
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
        
        else if (GetComponent<Player>())
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
        else
        {
            Debug.LogError("Something died that is an missing Enemy or Player component");
        }
    }
}