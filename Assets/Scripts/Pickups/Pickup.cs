using Interfaces;
using UnityEngine;

namespace Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        private string _pickupType;

        public string GetPickupType() => _pickupType;
        
        public abstract void GivePickupEffect(Collider2D collision);
    }
}
