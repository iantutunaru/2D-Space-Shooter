using UnityEngine;

namespace Pickups
{
    public class Pickup : MonoBehaviour
    {
        [Header("Pickup Type")]
        [SerializeField] private bool shield = false;
    
        public bool IsShield => shield;
    }
}
