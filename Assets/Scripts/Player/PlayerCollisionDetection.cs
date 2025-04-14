using Managers;
using Pickups;
using Projectiles;
using UnityEngine;

namespace Player
{
    public class PlayerCollisionDetection : MonoBehaviour
    {
        [Header("Player References")]
        [SerializeField] private Player player;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerSounds playerSounds;
        [SerializeField] private PlayerPickupManager playerPickupManager;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (CheckIfHitByProjectile(collision))
            {
                return;
            }

            if (CheckIfCollidedWithEnemy(collision))
            {
                return;
            }

            if (CheckIfPlayerCanPickUp(collision))
            {
                return;
            }
        }

        private bool CheckIfHitByProjectile(Collider2D collision)
        {
            var projectile = collision.GetComponent<Projectile>();

            if (projectile == null) return false;

            if (!projectile.IsEnemy()) return false;
            
            if (player.CanBeDamaged())
            {
                playerHealth.DealDamage();
            }
                
            ObjectPoolManager.ReturnObjectToPool(projectile.gameObject);
                
            return true;

        }

        private bool CheckIfCollidedWithEnemy(Collider2D collision)
        {
            var enemy = collision.GetComponent<Enemy.Enemy>();

            if (enemy == null) return false;
            
            if (player.CanBeDamaged())
            {
                playerHealth.DealDamage();
            }
            
            return true;

        }

        private bool CheckIfPlayerCanPickUp(Collider2D collision)
        {
            var pickup = collision.GetComponent<Pickup>();

            if (pickup == null) return false;

            if (!pickup.IsShield) return true;
            
            if (player.CanBeDamaged())
            {
                playerSounds.PlayShieldSound();
                playerPickupManager.PickedShieldUp();
            }
                
            ObjectPoolManager.ReturnObjectToPool(pickup.gameObject);

            return true;

        }
    }
}
