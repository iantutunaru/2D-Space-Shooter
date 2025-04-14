using UnityEngine;

namespace Player
{
    public class PlayerPickupManager : MonoBehaviour
    {
        [Header("Pickup Types")]
        [SerializeField] private PlayerShield playerShield;

        public void PickedShieldUp()
        {
            playerShield.TurnShieldOn();
        }
    }
}
