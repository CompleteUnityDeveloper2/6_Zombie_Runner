using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] Transform weaponPosition;
    GameObject weaponObject;

    public void PutWeaponInHand(GameObject weaponPrefab)
    {
        Destroy(weaponObject);
        weaponObject = Instantiate(weaponPrefab, transform.position, transform.rotation);
        weaponObject.transform.parent = gameObject.transform;
    }
  
}
