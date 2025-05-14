using UnityEngine;

namespace Player
{
    public class PlayerShield : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private GameObject playerShield;
        [Tooltip("How many seconds will the shield last.")]
        [SerializeField] private float shieldDuration = 5f;
        
        private float _shieldTimer;
        private bool _isShieldActive;

        private void OnEnable()
        {
            _shieldTimer = 0;
            _isShieldActive = false;
        }
    
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
            playerHealth.ToggleDamage();
            playerShield.SetActive(true);
            
            _shieldTimer = 0;
            _isShieldActive = true;
        }

        private void TurnShieldOff()
        {
            playerHealth.ToggleDamage();
            playerShield.SetActive(false);
            
            _shieldTimer = 0;
            _isShieldActive = false;
        }
    }
}
