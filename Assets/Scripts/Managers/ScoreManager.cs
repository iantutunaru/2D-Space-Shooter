using UI;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        private int _score = 0;
        
        public static ScoreManager Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
            Actions.Actions.OnEnemyDestroyed += AddScore;
        }

        public int GetScore()
        {
            return _score;
        }
        
        private void OnEnable()
        {
            Actions.Actions.OnEnemyDestroyed += AddScore;
        }

        private void OnDisable()
        {
            Actions.Actions.OnEnemyDestroyed -= AddScore;
        }

        private void OnDestroy()
        {
            Actions.Actions.OnEnemyDestroyed -= AddScore;
        }

        private void AddScore(Enemy.Enemy enemy)
        {
            _score += enemy.GetScoreForKill();
            GameUI.Instance.SetScoreText(_score);
        }
    }
}

