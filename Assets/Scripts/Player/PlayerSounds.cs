using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerSounds : Sounds.Sounds
    {
        [Header("Player Sounds")]
        [SerializeField] private AudioClip[] shootingSounds;
        
        [Header("Pickup Sounds")]
        [SerializeField] private AudioClip shieldSound;

        public void PlayShootingSounds()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shootingSounds, transform, 0.4f);
        }
        
        public void PlayShieldSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shieldSound, transform, 1f);
        }
    }
}