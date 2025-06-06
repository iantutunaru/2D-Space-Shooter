using Interfaces;
using UnityEngine;

namespace Pickups
{
    public class PickupCollisionDetection : MonoBehaviour, ICollidable
    {
        [SerializeField] private Pickup pickup;
        
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (pickup.Returned) return;
            
            if (CheckIfCollidedWithPlayer(collision))
            {
                    pickup.GivePickupEffect(collision);
            }
        }

        private bool CheckIfCollidedWithPlayer(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();

            return player != null;
        }
    }
}
