using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerSounds : Sounds.Sounds
    {
        [Range(0.01f, 1.0f)]
        [SerializeField] private float shieldSoundVolume = 1f;
        
        [Header("Pickup Sounds")]
        [SerializeField] private AudioClip shieldSound;
        
        public void PlayShieldSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shieldSound, transform, shieldSoundVolume);
        }
    }
}