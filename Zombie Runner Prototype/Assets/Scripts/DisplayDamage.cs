using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for displaying hit effects when player is damaged

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float splatterTime = 0.3f;
    [SerializeField] Canvas impactCanvas;   
    // Start is called before the first frame update
    void Start()
    {
        impactCanvas.enabled = false; 
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }
    
    IEnumerator ShowSplatter()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(splatterTime);
        impactCanvas.enabled = false;
    }
}
