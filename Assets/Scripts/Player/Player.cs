using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [Header("Player References")]
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerInput playerInput;
    
        [Header("Player Variables")]
        [Tooltip("Player's maximum health. Minimum is 1.")]
        [SerializeField] private float maxHealth = 4f;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private BoxCollider2D playerCollider;
    
        [Header("Player Sprites")]
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private SpriteRenderer engineSprite;
        [SerializeField] private SpriteRenderer enginePowerSprite;
        [SerializeField] private SpriteRenderer weaponsSprite;
    
        private bool _canBeDamaged = true;
        private Transform _startingPosition;

        public void Init(Transform startingPosition)
        {
            _startingPosition = startingPosition;
        }
    
        public void Start()
        {
            Actions.Actions.NewPlayerJoined(this);
            
            StartGame();
        }
        
        public void ToggleDamage()
        {
            _canBeDamaged = !_canBeDamaged;
        }
    
        public bool CanBeDamaged() => _canBeDamaged;

        private void StartGame()
        {
            playerInput.SwitchCurrentActionMap("Player");
            
            transform.position = _startingPosition.position;
            
            playerHealth.Init(maxHealth);
        }

        public void GameOver()
        { 
            playerRigidbody.velocity = Vector3.zero;
            playerCollider.enabled = false;
            playerSprite.enabled = false;
            engineSprite.enabled = false;
            enginePowerSprite.enabled = false; 
            weaponsSprite.enabled = false;
    
            playerInput.SwitchCurrentActionMap("UI");
            Actions.Actions.GameOver();
        }
    }
}
