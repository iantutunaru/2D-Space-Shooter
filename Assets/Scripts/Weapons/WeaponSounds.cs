using Managers;
using UnityEngine;

namespace Weapons
{
    public class WeaponSounds : MonoBehaviour
    {
        [SerializeField] private AudioClip[] shootingSounds;

        public void PlayShootingSounds()
        {
            SoundFXManager.Instance.PlaySoundFXClip(shootingSounds, transform, 0.25f);
        }
    }
}
