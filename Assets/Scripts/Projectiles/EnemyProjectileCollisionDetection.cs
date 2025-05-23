using UnityEngine;

namespace Projectiles
{
    public class EnemyProjectileCollisionDetection : ProjectileCollisionDetection
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Returned) return;
            
            if (CheckIfEnemyIsShotByEnemy(collision)) return;
            
            DealDamageIfHitByProjectile(collision);
        }
        
        private bool CheckIfEnemyIsShotByEnemy(Collider2D collision)
        {
            var enemy = collision.GetComponent<Enemy.Enemy>();

            return projectile.IsEnemy() && enemy != null;
        }
    }
}
