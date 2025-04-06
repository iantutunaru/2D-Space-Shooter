using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScoreManager scoreManager;
    
    [SerializeField] private GameObject enemyLineFormation;
    [SerializeField] private Transform minEnemySinSpawnPoint;
    [SerializeField] private Transform maxEnemySinSpawnPoint;
    [SerializeField] private int minEnemies = 1;
    [SerializeField] private int maxEnemies = 5;
    
    [SerializeField] private GameObject asteroids;
    [SerializeField] private Transform minAsteroidSpawnPoint;
    [SerializeField] private Transform maxAsteroidSpawnPoint;
    
    [SerializeField] private GameObject largeAsteroid;
    [SerializeField] private Transform minLargeAsteroidSpawnPoint;
    [SerializeField] private Transform maxLargeAsteroidSpawnPoint;
    
    [SerializeField] private int minAsteroids = 5;
    [SerializeField] private int maxAsteroids = 15;

    [SerializeField] private GameObject shieldPickup;
    [SerializeField] private Transform minShieldSpawnPoint;
    [SerializeField] private Transform maxShieldSpawnPoint;
    
    //private readonly int _enemyWave = 0;
    //private readonly int _asteroidWave = 1;
    
    private float _minSinSpawnTransformX, _maxSinSpawnTransformX;
    private float _minAsteroidTransformX, _maxAsteroidTransformX;
    private float _minLargeAsteroidTransformX, _maxLargeAsteroidTransformX;
    private float _minShieldSpawnTransformX, _maxShieldSpawnTransformX;
    
    public void Start()
    {
        _minSinSpawnTransformX = minEnemySinSpawnPoint.position.x;
        _maxSinSpawnTransformX = maxEnemySinSpawnPoint.position.x;
        
        _minAsteroidTransformX = minAsteroidSpawnPoint.position.x;
        _maxAsteroidTransformX = maxAsteroidSpawnPoint.position.x;
        
        _minLargeAsteroidTransformX = minLargeAsteroidSpawnPoint.position.x;
        _maxLargeAsteroidTransformX = maxLargeAsteroidSpawnPoint.position.x;
        
        _minShieldSpawnTransformX = minShieldSpawnPoint.position.x;
        _maxShieldSpawnTransformX = maxShieldSpawnPoint.position.x;
    }

    public void SpawnWave(int waveType)
    {
        switch (waveType)
        {
            case 1:
                SpawnLineFormation();
                break;
            case 2:
                SpawnAsteroids();
                break;
            case 3:
                SpawnLargeAsteroid();
                break;
            case 0:
                Debug.Log ("ERROR: Wave Type out of range.");
                break;
        }
    }

    private void SpawnLineFormation()
    {
        Vector3 enemySpawnPoint = new Vector3(Random.Range(_minSinSpawnTransformX, _maxSinSpawnTransformX), minEnemySinSpawnPoint.position.y, minEnemySinSpawnPoint.position.z);
        GameObject newWave = Instantiate(enemyLineFormation, enemySpawnPoint, Quaternion.identity);
        
        LineFormation newLineFormation = newWave.GetComponent<LineFormation>();
        newLineFormation.SetScoreManager(scoreManager);
        newLineFormation.PopulateLineFormation(Random.Range(minEnemies, maxEnemies));
    }

    private void SpawnAsteroids()
    {
        Vector3 asteroidSpawnPoint = new Vector3(Random.Range(_minAsteroidTransformX, _maxAsteroidTransformX), minAsteroidSpawnPoint.position.y, minAsteroidSpawnPoint.position.z);
        GameObject spawnedAsteroids = Instantiate(asteroids, asteroidSpawnPoint, Quaternion.identity);

        ObstacleLine obstacleLine = spawnedAsteroids.GetComponent<ObstacleLine>();
        obstacleLine.SetScoreManager(scoreManager);
        obstacleLine.PopulateObstacleLine();
    }

    private void SpawnLargeAsteroid()
    {
        Vector3 largeAsteroidSpawnPoint = new Vector3(Random.Range(_minLargeAsteroidTransformX, _maxLargeAsteroidTransformX), minLargeAsteroidSpawnPoint.position.y, minLargeAsteroidSpawnPoint.position.z);
        Quaternion asteroidRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        
        GameObject spawnedLargeAsteroid = Instantiate(largeAsteroid, largeAsteroidSpawnPoint, asteroidRotation);
        spawnedLargeAsteroid.GetComponent<Enemy>().Init(scoreManager);
    }

    public void SpawnPickup()
    {
        SpawnShieldPickup();
    }

    private void SpawnShieldPickup()
    {
        Vector3 shieldSpawnPoint = new Vector3(Random.Range(_minShieldSpawnTransformX, _maxShieldSpawnTransformX), minShieldSpawnPoint.position.y, minShieldSpawnPoint.position.z);
        
        GameObject newShieldPickup = Instantiate(shieldPickup, shieldSpawnPoint, Quaternion.identity);
    }
}
