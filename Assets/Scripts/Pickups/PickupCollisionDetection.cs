using Interfaces;
using Managers;
using Player;
using UnityEngine;

namespace Pickups
{
    public class PickupCollisionDetection : MonoBehaviour, ICollidable
    {
        [SerializeField] private Pickup pickup;
    
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (CheckIfColliderWithPlayer(collision))
            {
                if (pickup.IsShield)
                {
                    if (CheckIfPlayerCanUseShield(collision))
                    {
                        GivePlayerShield(collision);
                    }
                }
            }
        }

        private bool CheckIfColliderWithPlayer(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();

            return player != null;
        }

        private bool CheckIfPlayerCanUseShield(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();

            return player.CanBeDamaged();
        }

        private void GivePlayerShield(Collider2D collision)
        {
            var playerPickupManager = collision.GetComponent<PlayerPickupManager>();
        
            playerPickupManager.PickedShieldUp();
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
