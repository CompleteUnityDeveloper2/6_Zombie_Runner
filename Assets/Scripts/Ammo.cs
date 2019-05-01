using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: ammo is current on the individuals weapons. May be better stored in weapon system.
// rename to weapon


public class Ammo : MonoBehaviour
{
    [SerializeField] int[] currentAmmo = {10, 0, 0};

    public int GetCurrentAmmo(AmmoType type)
    {
        return currentAmmo[(int)type];
    }

    public void ReduceAmmo(AmmoType type)
    {
        if (GetCurrentAmmo(type) <= 0)
        {
            Debug.Log("Out of Ammo");
            // Play the 'no ammo' sound
            return;
            
        }
        else
        {
            currentAmmo[(int)type] --;
        }
    }

    public void IncreaseAmmo(AmmoType type, int ammoAmount)
    {
        currentAmmo[(int)type] += ammoAmount;
    }
}
