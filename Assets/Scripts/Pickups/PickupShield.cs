using Managers;
using Player;
using UnityEngine;

namespace Pickups
{
    public class PickupShield : Pickup
    {
        private string _pickupType = "Shield";

        public override void GivePickupEffect(Collider2D collision)
        {
            if (!CheckIfPlayerCanUseShield(collision)) return;
            
            var playerPickupManager = collision.GetComponent<PlayerPickupManager>();
        
            playerPickupManager.PickedShieldUp();
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
        
        private bool CheckIfPlayerCanUseShield(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();

            return player.CanBeDamaged();
        }
    }
}