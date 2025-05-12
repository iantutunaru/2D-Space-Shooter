using Interfaces;
using UnityEngine;

namespace Pickups
{
    public abstract class Pickup : MonoBehaviour
    {
        public bool Returned;
        public abstract void GivePickupEffect(Collider2D collision);
    }
}
