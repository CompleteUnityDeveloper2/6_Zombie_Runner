using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: ammo is current on the individuals weapons. May be better stored in weapon system.
// rename to weapon


public class Ammo : MonoBehaviour
{
    [SerializeField] int currentAmmo = 10;
    AmmoDisplay ammoDisplay;

    private void Start() 
    {
        ammoDisplay = FindObjectOfType<AmmoDisplay>();  
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void ReduceAmmo()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("Out of Ammo");
            // Play the 'no ammo' sound
            return;
            
        }
        else
        {
            currentAmmo --;
            ammoDisplay.UpdateAmmoDisplay(currentAmmo);
        }
    }

    public void IncreaseAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        ammoDisplay.UpdateAmmoDisplay(currentAmmo);
    }
}
