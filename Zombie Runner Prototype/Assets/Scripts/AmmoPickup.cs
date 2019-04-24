using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            print("player entered me... the horror");
            other.GetComponentInChildren<Ammo>().IncreaseAmmo(ammoAmount);
            //TODO: play sound
            Destroy(gameObject);
        }
    }
}
