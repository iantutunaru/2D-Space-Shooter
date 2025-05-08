using UnityEngine;

namespace Player
{
    public class PlayerPickupManager : MonoBehaviour
    {
        [Header("Pickup Types")]
        [SerializeField] private PlayerShield playerShield;
        [SerializeField] private PlayerSounds playerSounds;

        public void PickedShieldUp()
        {
            playerShield.TurnShieldOn();
            playerSounds.PlayShieldSound();
        }
    }
}
