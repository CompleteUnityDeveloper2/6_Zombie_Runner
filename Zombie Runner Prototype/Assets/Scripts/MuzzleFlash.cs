using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleVFX;

    public void PlayMuzzleVFX()
    {
        muzzleVFX.Play();
    }
}
