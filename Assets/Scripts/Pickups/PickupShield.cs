using Managers;
using Player;
using UnityEngine;

namespace Pickups
{
    public class PickupShield : Pickup
    {
        private void OnEnable()
        {
            Returned = false;
        }

        public override void GivePickupEffect(Collider2D collision)
        {
            if (Returned) return;
            
            if (!CheckIfPlayerCanUseShield(collision)) return;
            
            var playerPickupManager = collision.GetComponent<PlayerPickupManager>();
        
            playerPickupManager.PickedShieldUp();
            
            Returned = true;
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
        
        private bool CheckIfPlayerCanUseShield(Collider2D collision)
        {
            var playerHealth = collision.gameObject.GetComponent<Player.PlayerHealth>();

            return playerHealth.CanBeDamaged();
        }
    }
}