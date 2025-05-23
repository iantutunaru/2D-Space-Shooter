using UnityEngine;

namespace Projectiles
{
    public class PlayerProjectileCollisionDetection : ProjectileCollisionDetection
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Returned) return;
            
            if (CheckIfPlayerIsShotByPlayer(collision)) return;
            
            DealDamageIfHitByProjectile(collision);
        }
        
        private bool CheckIfPlayerIsShotByPlayer(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();

            return !projectile.IsEnemy() && player != null;
        }
    }
}
