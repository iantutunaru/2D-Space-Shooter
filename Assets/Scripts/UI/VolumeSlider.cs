using Managers;
using UnityEngine;

namespace UI
{
    public class VolumeSlider : MonoBehaviour
    {
        public void SetMasterVolume(float level)
        {
            SoundMixerManager.Instance.SetMasterVolume(level);
        }

        public void SetSoundFXVolume(float level)
        {
            SoundMixerManager.Instance.SetSoundFXVolume(level);
        }

        public void SetMusicVolume(float level)
        {
            SoundMixerManager.Instance.SetMusicVolume(level);
        }
    }
}
