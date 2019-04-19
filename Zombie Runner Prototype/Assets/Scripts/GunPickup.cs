using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            print("player entered me... the horror");
            //GetComponent<WeaponSystem>().EquipWeapon(weapon);
        }
    }
}
