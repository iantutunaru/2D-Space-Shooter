using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private float timeBetweenWaves = 5f;
        [SerializeField] private float timeBetweenPickups = 15f;
    
        [Header("Manager References")]
        [SerializeField] private SpawnManager spawnManager;
    
        private float _waveTimer;
        private float _pickupTimer;
        
        private const int OutOfBoundsWave = 0;
        private const int LineFormationWave = 1;
        private const int AsteroidWave = 2;
        private const int LargeAsteroidWave = 3;

        private void Start()
        {
            _waveTimer = 0;
            _pickupTimer = 0;
        }

        private void FixedUpdate()
        {
            CreateWave();
            CreatePickup();
        }

        private void CreateWave()
        {
            if (_waveTimer >= timeBetweenWaves)
            {
                SpawnWave();
                
                _waveTimer = 0.0f;
            } else {
                _waveTimer += Time.fixedDeltaTime;
            }
        }
        
        private void SpawnWave()
        {
            var waveType = ChooseWaveType();
        
            switch (waveType)
            {
                case LineFormationWave:
                    spawnManager.SpawnLineFormation();
                    break;
                case AsteroidWave:
                    spawnManager.SpawnAsteroids();
                    break;
                case LargeAsteroidWave:
                    spawnManager.SpawnLargeAsteroid();
                    break;
                case OutOfBoundsWave:
                    Debug.LogWarning("ERROR: Wave Type out of range.");
                    break;
            }
        }
    
        private static int ChooseWaveType()
        {
            return Random.Range(LineFormationWave, LargeAsteroidWave+1);
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
                _pickupTimer += Time.fixedDeltaTime;
            }
        }
    }
}