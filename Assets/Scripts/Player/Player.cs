using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static event Action GameOver;
        
        [Header("Player References")]
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Transform startingPosition;
    
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

        public void Init(Transform startingPosition)
        {
            this.startingPosition = startingPosition;
        }
    
        public void Start()
        {
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
            
            transform.position = startingPosition.position;
            
            playerHealth.Init(maxHealth);
        }

        public void Die()
        { 
            playerRigidbody.velocity = Vector3.zero;
            playerCollider.enabled = false;
            playerSprite.enabled = false;
            engineSprite.enabled = false;
            enginePowerSprite.enabled = false; 
            weaponsSprite.enabled = false;
    
            playerInput.SwitchCurrentActionMap("UI");
            
            GameOver?.Invoke();
        }
    }
}
