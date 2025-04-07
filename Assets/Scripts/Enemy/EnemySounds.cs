using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] deathSounds;

    public void PlayDeathSound()
    {
        SoundFXManager.Instance.PlaySoundFXClip(deathSounds, transform, 1f);
    }
}
