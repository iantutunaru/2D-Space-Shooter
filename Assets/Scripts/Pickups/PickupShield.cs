using Managers;
using Player;
using UnityEngine;

namespace Pickups
{
    public class PickupShield : Pickup
    {
        private bool _returned = false;
        
        public new bool Returned => _returned;

        private void OnEnable()
        {
            _returned = false;
        }

        public override void GivePickupEffect(Collider2D collision)
        {
            if (_returned) return;
            
            if (!CheckIfPlayerCanUseShield(collision)) return;
            
            var playerPickupManager = collision.GetComponent<PlayerPickupManager>();
        
            playerPickupManager.PickedShieldUp();
            
            _returned = true;
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
        
        private bool CheckIfPlayerCanUseShield(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();

            return player.CanBeDamaged();
        }
    }
}