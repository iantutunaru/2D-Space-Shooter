using Managers;
using Projectiles;
using UnityEngine;

namespace Enemy
{
    public class EnemyCollisionDetection : MonoBehaviour
    {
        [SerializeField] private bool canBeDestroyed = false;
        [SerializeField] private float screenBoundsPosition = 13.2f;
    
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemyHealth enemyHealth;

        private void Awake()
        {
            canBeDestroyed = false;
        }
        
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!canBeDestroyed) return;
        
            if (CheckIfHitByPlayerProjectile(collision)) return;
        
            if (CheckIfHitByPlayer(collision)) return;
        }

        private bool CheckIfHitByPlayerProjectile(Collider2D collision)
        {
            var projectile = collision.GetComponent<Projectile>();

            if (projectile == null) return false;

            if (projectile.IsEnemy()) return false;
        
            enemyHealth.DealDamage();
                
            ObjectPoolManager.ReturnObjectToPool(projectile.gameObject);
                
            return true;
        }

        private bool CheckIfHitByPlayer(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();

            if (player == null) return false;
        
            enemyHealth.DealDamage();
        
            return true;
        }
    }
}