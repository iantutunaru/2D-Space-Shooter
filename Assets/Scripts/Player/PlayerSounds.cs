using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerSounds : MonoBehaviour
    {
        [Header("Player Sounds")]
        [SerializeField] private AudioClip[] shootingSounds;
        [SerializeField] private AudioClip damageSound;
        [SerializeField] private AudioClip deathSound;
        
        [Header("Pickup Sounds")]
        [SerializeField] private AudioClip shieldSound;

        public void PlayShootingSounds()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shootingSounds, transform, 0.4f);
        }

        public void PlayDeathSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(deathSound, transform, 1f);
        }

        public void PlayDamageSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(damageSound, transform, 0.4f);
        }

        public void PlayShieldSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shieldSound, transform, 1f);
        }
    }
}