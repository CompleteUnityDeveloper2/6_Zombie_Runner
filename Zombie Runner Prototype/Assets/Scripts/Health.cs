using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHitPoints = 100f;

    bool isDead = false;
    // exposed so we can see that we are being hit
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

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        if(!GetComponent<Animator>()) return;
        GetComponent<Animator>().SetTrigger("die");
    }
}