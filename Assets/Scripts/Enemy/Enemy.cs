using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyCollisionDetection collisionDetection;
    [SerializeField] private EnemyMovement movement;
    
    public void Init(ScoreManager scoreManager)
    {
        Debug.Log("Enemy initialized.");
        collisionDetection.SetScoreManager(scoreManager);
    }
}
