using Managers;
using UnityEngine;

namespace Sounds
{
    public class Sounds : MonoBehaviour
    {
        [Header("Sound Parameters")]
        [Range(0.01f, 1.0f)]
        [SerializeField] private float damageSoundVolume = 0.4f;
        [Range(0.01f, 1.0f)]
        [SerializeField] private float deathSoundVolume = 1f;
        [Range(0.01f, 1.0f)]
        [SerializeField] private float shootingSoundsVolume = 0.25f;
        
        [Header("Sounds")]
        [SerializeField] private AudioClip[] damageSounds;
        [SerializeField] private AudioClip[] deathSounds;
        [SerializeField] private AudioClip[] shootingSounds;
    
        public void PlayDeathSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(deathSounds, transform, deathSoundVolume);
        }

        public void PlayDamageSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(damageSounds, transform, damageSoundVolume);
        }
        
        public void PlayShootingSounds()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shootingSounds, transform, shootingSoundsVolume);
        }
    }
}
