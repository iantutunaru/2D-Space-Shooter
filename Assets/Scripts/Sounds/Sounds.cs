using Managers;
using UnityEngine;

namespace Sounds
{
    public abstract class Sounds : MonoBehaviour
    {
        [Header("Sounds")]
        [SerializeField] private AudioClip[] damageSounds;
        [SerializeField] private AudioClip[] deathSounds;
    
        public void PlayDeathSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(deathSounds, transform, 1f);
        }

        public void PlayDamageSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(damageSounds, transform, 0.4f);
        }
    }
}
