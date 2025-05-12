using System;
using Managers;
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
        
        public bool CanBeDamaged() => _canBeDamaged;
        
        public void Start()
        {
            PlayerManager.Instance.AddNewPlayer(this);
        }
        
        public void OnEnable()
        {
            StartGame();
        }
        
        private void StartGame()
        {
            playerInput.SwitchCurrentActionMap("Player");
            
            transform.position = startingPosition.position;
            
            playerHealth.Init(maxHealth);
        }

        public void ChangeControlScheme(string controlScheme)
        {
            playerInput.SwitchCurrentActionMap(controlScheme);
        }
        
        public void ToggleDamage()
        {
            _canBeDamaged = !_canBeDamaged;
        }

        public void Die()
        { 
            DisableMovementAndVisuals();

            GameOver?.Invoke();
        }

        private void DisableMovementAndVisuals()
        {
            playerRigidbody.velocity = Vector3.zero;
            playerCollider.enabled = false;
            playerSprite.enabled = false;
            engineSprite.enabled = false;
            enginePowerSprite.enabled = false; 
            weaponsSprite.enabled = false;
        }
    }
}
