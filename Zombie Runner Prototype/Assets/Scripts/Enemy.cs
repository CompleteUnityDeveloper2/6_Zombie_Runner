using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 10f;
    [SerializeField] Canvas damageImpact;

    // add attack behaviour(s)
    // add SFX

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<Health>().TakeDamage(damage);
        damageImpact.GetComponent<DisplayDamage>().ShowDamageImpact();
    }

    public void TimeToDie()
    {
        GetComponent<Animator>().SetTrigger("die");
    }

}
