using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;
    Ammo currentAmmoSlot;
    int currentAmmoAmount;

    public void UpdateAmmoSlot(Ammo ammoSlot)
    {
        currentAmmoSlot = ammoSlot;
        //Debug.Log(currentAmmoSlot.name);
        currentAmmoAmount = currentAmmoSlot.GetCurrentAmmo();
        //Debug.Log(currentAmmoAmount);
        ammoText.text = currentAmmoAmount.ToString();
    }

    public void UpdateAmmoDisplay(int currentAmmo)
    {
        ammoText.text = currentAmmo.ToString();
    }
}
