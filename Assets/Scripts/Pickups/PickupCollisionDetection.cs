using Interfaces;
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
                    pickup.GivePickupEffect(collision);
            }
        }

        private bool CheckIfColliderWithPlayer(Collider2D collision)
        {
            var player = collision.gameObject.GetComponent<Player.Player>();

            return player != null;
        }
    }
}
