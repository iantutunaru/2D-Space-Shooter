using System;
using Enemy;
using UI;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        
        private int _score = 0;
        
        public static ScoreManager Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public int GetScore()
        {
            return _score;
        }
        
        private void OnEnable()
        {
            EnemyHealth.OnEnemyDestroyed += AddScore;
        }

        private void OnDisable()
        {
            EnemyHealth.OnEnemyDestroyed -= AddScore;
        }

        private void AddScore(Enemy.Enemy enemy)
        {
            _score += enemy.GetScoreForKill();
            
            ScoreChanged?.Invoke(_score);
        }
    }
}

