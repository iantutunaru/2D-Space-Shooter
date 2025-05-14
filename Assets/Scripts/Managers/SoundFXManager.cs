using Audio;
using UnityEngine;

namespace Managers
{
    public class SoundFXManager : MonoBehaviour
    {
        public static SoundFXManager Instance;
    
        [SerializeField] private AudioSource soundFXObject;

        private float _audioTimer;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
        {
            var audioSourceGameObject = ObjectPoolManager.SpawnObject(soundFXObject.gameObject, 
                spawnTransform.position, Quaternion.identity, ObjectPoolManager.PoolType.AudioSource);
        
            var audioSource = audioSourceGameObject.GetComponent<AudioSource>();
        
            audioSource.clip = audioClip;
        
            audioSource.volume = volume;
        
            audioSource.Play();
        
            audioSourceGameObject.GetComponent<ReturnAudioToPool>().StartTimer(audioSource.clip.length);
        }
    
        public void PlaySoundFXClip(AudioClip[] audioClips, Transform spawnTransform, float volume)
        {
            var randomClip = Random.Range(0, audioClips.Length);
        
            var audioSourceGameObject = ObjectPoolManager.SpawnObject(soundFXObject.gameObject, 
                spawnTransform.position, Quaternion.identity, ObjectPoolManager.PoolType.AudioSource);
            
            var audioSource = audioSourceGameObject.GetComponent<AudioSource>();
        
            audioSource.clip = audioClips[randomClip];
        
            audioSource.volume = volume;
        
            audioSource.Play();
        
            audioSourceGameObject.GetComponent<ReturnAudioToPool>().StartTimer(audioSource.clip.length);
        }
    }
}
