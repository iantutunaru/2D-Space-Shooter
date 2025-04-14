using UnityEngine;
using UnityEngine.Audio;

namespace Managers
{
    public class SoundMixerManager : MonoBehaviour
    {
        public static SoundMixerManager Instance;
        
        [SerializeField] private AudioMixer audioMixer;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void SetMasterVolume(float level)
        {
            audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
        }

        public float GetMasterVolume()
        {
            audioMixer.GetFloat("masterVolume", out var masterVolume);
            
            return Mathf.Pow(10f, masterVolume / 20f);
        }

        public void SetSoundFXVolume(float level)
        {
            audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
        }
        
        public float GetSoundFXVolume()
        {
            audioMixer.GetFloat("soundFXVolume", out var soundFXVolume);
            Debug.Log(soundFXVolume);
            
            return Mathf.Pow(10f, soundFXVolume / 20f);
        }

        public void SetMusicVolume(float level)
        {
            audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
        }
        
        public float GetMusicVolume()
        {
            audioMixer.GetFloat("musicVolume", out var musicVolume);
            
            return Mathf.Pow(10f, musicVolume / 20f);
        }
    }
}
