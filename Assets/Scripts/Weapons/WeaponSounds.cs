using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] shootingSounds;

    public void PlayShootingSounds()
    {
        SoundFXManager.Instance.PlaySoundFXClip(shootingSounds, transform, 0.25f);
    }
}
