using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// note: responsible for playing VFX when player shoots

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleVFX;

    public void PlayMuzzleVFX()
    {
        muzzleVFX.Play();
    }
}
