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
            if (!enemyHealth.CanBeDamaged) return;

            CheckIfCollidedWithPlayer(collision);
        }

        private void CheckIfCollidedWithPlayer(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();
            
            if (player == null) return;

            if (player.CanBeDamaged())
            {
                var playerHealth = collision.GetComponent<PlayerHealth>();
                playerHealth.Damage();
            }
            
            enemyHealth.Damage();
        }
    }
}