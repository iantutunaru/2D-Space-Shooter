using UnityEngine;

namespace Managers
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private float timeBetweenWaves = 5f;
        [SerializeField] private float timeBetweenPickups = 15f;
    
        [Header("Manager References")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private SpawnManager spawnManager;
    
        private float _waveTimer = 0.0f;
        private float _pickupTimer = 0.0f;
    
        public void Update()
        {
            CreateWave();
            CreatePickup();
        }

        private void CreateWave()
        {
            if (_waveTimer >= timeBetweenWaves)
            {
                spawnManager.SpawnWave();
                _waveTimer = 0.0f;
            } else {
                _waveTimer += Time.deltaTime;
            }
        }

        private void CreatePickup()
        {
            if (_pickupTimer >= timeBetweenPickups)
            {
                spawnManager.SpawnPickup();
                _pickupTimer = 0.0f;
            }
            else
            {
                _pickupTimer += Time.deltaTime;
            }
        }
    }
}