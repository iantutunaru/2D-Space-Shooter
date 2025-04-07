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
    
    private bool _canBeDestroyed = true;

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

    public void StartGame()
    {
        transform.position = startingPosition.position;
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
