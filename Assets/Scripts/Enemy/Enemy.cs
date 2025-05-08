using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int scoreGain;
        [SerializeField] private int health = 1;
        
        [Header("Enemy References")]
        [SerializeField] private EnemyHealth enemyHealth;
        
        private void OnEnable()
        {
            enemyHealth.Init(health);
        }

        public int GetScoreForKill()
        {
            return scoreGain;
        }
    }
}
