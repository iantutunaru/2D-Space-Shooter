using UnityEngine;

namespace Player
{
    public class PlayerShield : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private GameObject playerShield;
        [Tooltip("How many seconds will the shield last.")]
        [SerializeField] private float shieldDuration = 5f;
        
        private float _shieldTimer = 0;
        private bool _isShieldActive = false;
    
        private void Update()
        {
            ShieldTimeLimit();
        }

        private void ShieldTimeLimit()
        {
            if (_shieldTimer >= shieldDuration && _isShieldActive)
            {
                TurnShieldOff();
            }
            else
            {
                _shieldTimer += Time.deltaTime;
            }
        }
        
        public void TurnShieldOn()
        {
            playerShield.SetActive(true);
            player.ToggleDamage();
            
            _shieldTimer = 0;
            _isShieldActive = true;
        }

        private void TurnShieldOff()
        {
            player.ToggleDamage();
            playerShield.SetActive(false);
            
            _shieldTimer = 0;
            _isShieldActive = false;
        }
    }
}
