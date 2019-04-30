using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//note: responsible for handling hitting and getting hit for enemies

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 10f;
    [SerializeField] DisplayDamage damageImpact;

    // add attack behaviour(s)
    // add SFX

    // so we can time damage with animation
    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }

    // so the health system can let animator know when its time to die
    public void TimeToDie()
    {
        GetComponent<Animator>().SetTrigger("die");
    }

}
