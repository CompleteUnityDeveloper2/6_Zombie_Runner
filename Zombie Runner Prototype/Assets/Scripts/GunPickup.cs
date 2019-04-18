using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] GameObject weaponPrefab;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            print("player entered me");
            other.GetComponent<WeaponSystem>().PutWeaponInHand(weaponPrefab);
        }
    }
}
