using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for handling health - current, increasing, decreasing

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO could add coroutine to allow for death sounds and whatnot
        GetComponent<DeathHandler>().HandleDeath();
    }
}