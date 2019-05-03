using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: ammo is current on the individuals weapons. May be better stored in weapon system.
// rename to weapon

// teaching a private class that sits in another class, which is serialized so we can implement in inspector 

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable] // ensure Unity can display in the editor
    
    // class starts
    class AmmoSlot  // this is a private class, used only in Ammo class
    {
        public AmmoType ammoType;
        public int ammo;  // public variable but it can only be used within Ammo because
        // AmmoSlot is a private class
    }
    // class ends

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        return ammoSlot.ammo;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        if (GetCurrentAmmo(ammoType) <= 0)
        {
            Debug.Log("Out of Ammo");
            // Play the 'no ammo' sound
            return;

        }
        else
        {
            GetAmmoSlot(ammoType).ammo--;
        }
    }

    public void IncreaseAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammo += ammoAmount;
    }

// goes through our slots and sees if there is a match to the type of ammo,
// then we can returns that slot

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)  
        {
            if (slot.ammoType == ammoType) return slot;
        }
        // if we haven't given a starting value to the ammo slot (in our list) then...
        // AmmoSlot newAmmoSlot = new AmmoSlot(); 
        // newAmmoSlot.ammoType = ammoType;
        // ammoSlots.Add(newAmmoSlot);
        // return newAmmoSlot;
        return null;
    }
}