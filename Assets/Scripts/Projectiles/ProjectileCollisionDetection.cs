using Interfaces;
using Managers;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileCollisionDetection : MonoBehaviour, IPoolReturnable
    {
        public bool Returned { get; set; }
        
        [SerializeField] private Projectile projectile;
        
        private void OnEnable()
        {
            Returned = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Returned) return;
            
            if (CheckIfPlayerIsShotByPlayer(collision)) return;
            
            if (CheckIfEnemyIsShotByEnemy(collision)) return;
            
            DealDamageIfHitByProjectile(collision);
        }
        
        private void DealDamageIfHitByProjectile(Collider2D collision)
        {
            var damageableObject = collision.GetComponent<IDamageable>();
            
            damageableObject?.Damage(projectile.projectileDamage);

            Returned = true;
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
        
        private bool CheckIfPlayerIsShotByPlayer(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();

            return !projectile.IsEnemy() && player != null;
        }

        private bool CheckIfEnemyIsShotByEnemy(Collider2D collision)
        {
            var enemy = collision.GetComponent<Enemy.Enemy>();

            return projectile.IsEnemy() && enemy != null;
        }
    }
}
