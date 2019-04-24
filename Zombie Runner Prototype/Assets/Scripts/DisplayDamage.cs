using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for displaying hit effects when player is damaged

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float splatterTime = 0.3f;   
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false; 
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }
    
    IEnumerator ShowSplatter()
    {
        GetComponent<Canvas>().enabled = true;
        yield return new WaitForSeconds(splatterTime);
        GetComponent<Canvas>().enabled = false;
    }
}
