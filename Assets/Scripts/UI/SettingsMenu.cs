using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Slider generalVolumeSlider;
        [SerializeField] private Slider musicVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;

        private void Start()
        {
            UpdateSliders();
        }

        private void OnEnable()
        {
            UpdateSliders();
        }

        private void UpdateSliders()
        {
            generalVolumeSlider.value = SoundMixerManager.Instance.GetMasterVolume();
            musicVolumeSlider.value = SoundMixerManager.Instance.GetMusicVolume();
            sfxVolumeSlider.value = SoundMixerManager.Instance.GetSoundFXVolume();
        }
    }
}