using UnityEngine;

namespace Player
{
    public class PlayerPickupManager : MonoBehaviour
    {
        [SerializeField] private PlayerSounds playerSounds;
        
        [Header("Pickup Types")]
        [SerializeField] private PlayerShield playerShield;
        
        public void PickedShieldUp()
        {
            playerShield.TurnShieldOn();
            playerSounds.PlayShieldSound();
        }
    }
}
