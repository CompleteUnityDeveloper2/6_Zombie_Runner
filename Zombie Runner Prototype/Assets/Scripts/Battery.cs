using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for improving the flashlight - brighter and bigger

public class Battery : MonoBehaviour
{
    [SerializeField] float addIntensity = 1f;
    [SerializeField] float restoreAngle = 90f;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            // good to test first that we have proper collision working
            Debug.Log("Player collided with");
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            Destroy(gameObject);
        }    
    }
}
