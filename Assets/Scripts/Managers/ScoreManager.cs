using System;
using Enemy;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public event Action<int> ScoreChanged;
        
        private int _score;
        
        public static ScoreManager Instance;
        
        private void Awake()
        {
            if (Instance != null) return;
            
            _score = 0;
            Instance = this;
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

