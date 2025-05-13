using Interfaces;
using UnityEngine;

namespace Pickups
{
    public abstract class Pickup : MonoBehaviour, IPoolReturnable
    {
        public bool Returned { get; set; }
        public abstract void GivePickupEffect(Collider2D collision);

    }
}
