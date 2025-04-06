using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFormation : MonoBehaviour
{
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] private Transform firstShip;
    [SerializeField] private int distanceBetweenShips;
    
    private ScoreManager _scoreManager;

    public void SetScoreManager(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }
    
    public void PopulateLineFormation(int numberOfShips)
    {
        Vector3 nextPosition = firstShip.position;
        
        for (int i = 0; i < numberOfShips; i++)
        {
            GameObject spawnedShip = Instantiate(shipPrefab, nextPosition, Quaternion.identity);
            spawnedShip.GetComponent<Enemy>().Init(_scoreManager);
            
            nextPosition = nextPosition + Vector3.up * distanceBetweenShips;
        }    
    }
}
