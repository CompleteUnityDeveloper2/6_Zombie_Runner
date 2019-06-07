using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    bool zoomedInToggle = false;
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] float zoomedOutFOV;
    [SerializeField] float zoomedInFOV;
    [SerializeField] float mouseZoomOutSensitivity = 2f;
    [SerializeField] float mouseZoomInSensitivity = .5f;

    RigidbodyFirstPersonController fpsController;

    private void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("pushed button");
            if (zoomedInToggle == false)
            {
                // final step would be to break these out as their own methods - zoomIn and zoomOut
                zoomedInToggle = true;
                firstPersonCamera.fieldOfView = zoomedInFOV;
                fpsController.mouseLook.XSensitivity = mouseZoomInSensitivity;
                fpsController.mouseLook.YSensitivity = mouseZoomInSensitivity;
            }
            else
            {
                zoomedInToggle = false;
                firstPersonCamera.fieldOfView = zoomedOutFOV;
                fpsController.mouseLook.XSensitivity = mouseZoomOutSensitivity;
                fpsController.mouseLook.YSensitivity = mouseZoomOutSensitivity;
            }
        }
    }    
    
}
