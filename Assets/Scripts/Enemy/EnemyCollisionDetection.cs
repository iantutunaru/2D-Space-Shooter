using Interfaces;
using Managers;
using Player;
using Projectiles;
using UnityEngine;

namespace Enemy
{
    public class EnemyCollisionDetection : MonoBehaviour, ICollidable
    {
        [SerializeField] private bool canBeDestroyed = false;
        [SerializeField] private float screenBoundsPosition = 13.2f;
    
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemyHealth enemyHealth;
        
        private void OnEnable()
        {
            canBeDestroyed = false;
        }

        private void OnDisable()
        {
            canBeDestroyed = false;
        }
    
        private void Update()
        {
            if (transform.position.y <= screenBoundsPosition)
            {
                canBeDestroyed = true;
            }    
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!canBeDestroyed) return;

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