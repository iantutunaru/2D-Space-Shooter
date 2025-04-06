using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float timeBetweenPickups = 15f;
    [SerializeField] private GameManager gameManager;
    
    private readonly int _enemyWave = 1;
    private readonly int _asteroidWave = 2;
    private readonly int _largeAsteroidWave = 3;
    
    private float _waveTimer = 0.0f;
    private int _waveCount = 1;
    private float _pickupTimer = 0.0f;
    private SpawnManager _spawnManager;

    public void Start()
    {
        _spawnManager = gameManager.SpawnManager;
    }

    public void Update()
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
            _waveCount += 1;
        } else {
            _waveTimer += Time.deltaTime;
        }
    }

    private void CreatePickup()
    {
        if (_pickupTimer >= timeBetweenPickups)
        {
            SpawnPickup();
            _pickupTimer = 0.0f;
        }
        else
        {
            _pickupTimer += Time.deltaTime;
        }
    }

    private void SpawnWave()
    {
        int waveType = chooseWaveType();
        
        _spawnManager.SpawnWave(waveType);
    }

    private int chooseWaveType()
    {
        return Random.Range(_enemyWave, _largeAsteroidWave+1);
    }

    public int GetWaveCount()
    {
        return _waveCount;
    }

    private void SpawnPickup()
    {
        _spawnManager.SpawnPickup();
    }
}
