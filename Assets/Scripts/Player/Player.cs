using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerShooting playerShooting;
    [SerializeField] private PlayerCollisionDetection playerCollisionDetection;
    [SerializeField] private PlayerPickupManager playerPickupManager;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private Transform startingPosition;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer engineSprite;
    [SerializeField] private SpriteRenderer enginePowerSprite;
    [SerializeField] private SpriteRenderer weaponsSprite;
    
    private bool _canBeDestroyed = true;
    
    public void Start()
    {
        StartGame();
    }

    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }
    
    private void OnEnable()
    {
        playerMovement.MovementSpeedChanged += OnMovementSpeedChanged;
    }

    private void OnDisable()
    {
        playerMovement.MovementSpeedChanged -= OnMovementSpeedChanged;
    }

    private void StartGame()
    {
        playerInput.SwitchCurrentActionMap("Player");
        transform.position = startingPosition.position;
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
        pauseMenu.GameOver();
    }

    private void OnMovementSpeedChanged(float movementSpeed)
    {
        playerAnimator.setMoveSpeed(movementSpeed);
    }

    public void TurnShieldOn()
    {
        playerPickupManager.TurnShieldOn();
        _canBeDestroyed = false;
    }

    public void TurnShieldOff()
    {
        _canBeDestroyed = true;
    }

    public bool CanBeDestroyed() => _canBeDestroyed;
}
