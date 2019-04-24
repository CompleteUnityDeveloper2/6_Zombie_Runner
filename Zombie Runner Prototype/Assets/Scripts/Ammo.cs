using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int startingAmmo = 10;
    
    // exposed for testing
    [SerializeField] int currentAmmo;
    
    void Start()
    {
        currentAmmo = startingAmmo;    
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
        }
    }

    public void IncreaseAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;        
    }
}
