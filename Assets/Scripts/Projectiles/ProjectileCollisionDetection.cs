using Interfaces;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileCollisionDetection : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (CheckIfPlayerIsShotByPlayer(collision)) return;
            
            if (CheckIfEnemyIsShotByEnemy(collision)) return;
            
            DealDamageIfHitByProjectile(collision);
        }
        
        private void DealDamageIfHitByProjectile(Collider2D collision)
        {
            var damageableObject = collision.GetComponent<IDamageable>();
            
            damageableObject?.Damage();
            
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
