using System.Collections;
using Managers;
using UnityEngine;

namespace Audio
{
    public class ReturnAudioToPool : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        private float _audioLength;
        private Coroutine _returnToPoolTimerCoroutine;

        private void Awake()
        {
            _audioLength = 0f;
        }
    
        public void StartTimer(float audioLength)
        {
            _audioLength = audioLength;
        
            _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
        }
    
        private IEnumerator ReturnToPoolAfterTime()
        {
            var elapsedTime = 0f;

            while (elapsedTime <= _audioLength)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}