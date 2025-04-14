using UnityEngine;

namespace Pickups
{
    public class Pickup : MonoBehaviour
    {
        [SerializeField] private PickupMovement pickupMovement;
        [SerializeField] private PickupSinMovePattern pickupSinMovePattern;
        [Header("Pickup Type")]
        [SerializeField] private bool shield = false;
    
        public bool IsShield => shield;
    }
}
