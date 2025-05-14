using Interfaces;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyCollisionDetection : MonoBehaviour, ICollidable
    {
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemyHealth enemyHealth;
        
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (enemyHealth.Returned) return;
            
            if (!enemyHealth.CanBeDamaged) return;

            CheckIfCollidedWithPlayer(collision);
        }

        private void CheckIfCollidedWithPlayer(Collider2D collision)
        {
            var playerHealth = collision.GetComponent<Player.PlayerHealth>();
            
            if (playerHealth == null) return;

            if (playerHealth.CanBeDamaged())
            {
                playerHealth.Damage();
            }
            
            enemyHealth.Damage();
        }
    }
}