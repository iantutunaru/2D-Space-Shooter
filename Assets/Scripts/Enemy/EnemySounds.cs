using Managers;
using UnityEngine;

namespace Enemy
{
    public class EnemySounds : MonoBehaviour
    {
        [SerializeField] private AudioClip[] damageSound;
        [SerializeField] private AudioClip[] deathSounds;

        public void PlayDeathSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(deathSounds, transform, 1f);
        }

        public void PlayDamageSound()
        {
            SoundFXManager.Instance.PlaySoundFXClip(damageSound, transform, 1f);
        }
    }
}
