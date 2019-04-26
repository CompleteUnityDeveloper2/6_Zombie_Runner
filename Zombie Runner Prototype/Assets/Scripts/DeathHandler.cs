using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas youDiedCanvas;

    void Start()
    {
        youDiedCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        youDiedCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<Weapon>().enabled = false;
        // give cursor control back to the player
        // (note: remember to put UI layer to high sort mode)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
 
}
