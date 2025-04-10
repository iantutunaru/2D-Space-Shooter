using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLine : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform firstObstacle;
    [SerializeField] private int distanceBetweenObstacles;
    
    private ScoreManager _scoreManager;
    private int _numberOfObstacles = 2;

    public void SetScoreManager(ScoreManager scoreManager)
    {
        Debug.Log("Score manager set in the ObstacleLine.");
        _scoreManager = scoreManager;
    }
    
    public void PopulateObstacleLine()
    {
        Vector3 nextPosition = firstObstacle.position;
        Quaternion asteroidRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        
        for (int i = 0; i < _numberOfObstacles; i++)
        {
            GameObject spawnedObstacle = ObjectPoolManager.SpawnObject(obstaclePrefab, nextPosition, asteroidRotation, ObjectPoolManager.PoolType.Enemy);
            spawnedObstacle.GetComponent<Enemy>().Init(_scoreManager);
            
            nextPosition = nextPosition + Vector3.right * distanceBetweenObstacles;
            asteroidRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }    
    }
}
