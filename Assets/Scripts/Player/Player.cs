using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [Header("Player References")]
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Transform startingPosition;
    
        [Header("Player Variables")]
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private BoxCollider2D playerCollider;
    
        [Header("Player Sprites")]
        [SerializeField] private SpriteRenderer playerSprite;
        [SerializeField] private SpriteRenderer engineSprite;
        [SerializeField] private SpriteRenderer enginePowerSprite;
        [SerializeField] private SpriteRenderer weaponsSprite;
        
        private void Start()
        {
            PlayerManager.Instance.AddNewPlayerOnGameStart(this);
        }
        
        private void OnEnable()
        {
            transform.position = startingPosition.position;
        }

        public void ChangeControlScheme(string controlScheme)
        {
            playerInput.SwitchCurrentActionMap(controlScheme);
        }

        public void DisableMovementAndVisuals()
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
