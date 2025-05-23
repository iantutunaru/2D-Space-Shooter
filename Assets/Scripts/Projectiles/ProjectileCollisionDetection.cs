using Interfaces;
using Managers;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileCollisionDetection : MonoBehaviour, IPoolReturnable
    {
        public bool Returned { get; set; }
        
        [SerializeField] protected Projectile projectile;
        
        private void OnEnable()
        {
            Returned = false;
        }
        
        protected void DealDamageIfHitByProjectile(Collider2D collision)
        {
            var damageableObject = collision.GetComponent<IDamageable>();
            
            damageableObject?.Damage(projectile.projectileDamage);

            Returned = true;
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
