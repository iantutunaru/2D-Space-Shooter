using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] shootingSounds;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip shieldSound;

    public void PlayShootingSounds()
    {
        SoundFXManager.Instance.PlaySoundFXClip(shootingSounds, transform, 0.4f);
    }

    public void PlayDeathSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(deathSound, transform, 1f);
    }

    public void PlayShieldSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(shieldSound, transform, 1f);
    }
}