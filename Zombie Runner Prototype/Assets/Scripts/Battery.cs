using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float addIntensity = 1f;
    [SerializeField] float restoreAngle = 90f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            // good to show that we have proper collision first
            Debug.Log("Player collided with");
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            Destroy(gameObject);
        }    
    }
}
