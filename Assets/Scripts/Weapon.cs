using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

// note: responsible for handling shooting and raycasting
// rename weapon

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] Camera FPCamera;
    [SerializeField] GameObject hitImpactVFX;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        DisplayAmmo(); // Probably better in a seperate script
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    public Ammo AmmoSlot()
    {
        return ammoSlot;
    }

    private void Shoot()
    {
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleEffect();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
        }
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
            // print("I hit: " + hit.transform.name + "for " + damage);
            CreateHitImpact(hit);
        }
    }

    private void PlayMuzzleEffect()
    {
        MuzzleFlash muzzleFlash = GetComponentInChildren<MuzzleFlash>();

        if (muzzleFlash)
        {
            muzzleFlash.PlayMuzzleVFX();
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var impact = Instantiate(hitImpactVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .5f);
    }
}
