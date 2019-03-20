using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 10f;

    // add attack behaviour(s)
    // add SFX

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<Health>().TakeDamage(damage);
    }
}
