using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Action<Vector2> MovementInputChanged;
    public Action<float> MovementSpeedChanged;
    
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float movementSpeed = 1f;
    
    private Vector2 _movementInput;
    private float _minXMovement = -6.87f;
    private float _maxXMovement = 6.87f;
    private float _minYMovement = -13.2f;
    private float _maxYMovement = 13.2f;
    
    public void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
        
        MovementInputChanged?.Invoke(_movementInput);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = _movementInput * movementSpeed;
        
        MovementSpeedChanged?.Invoke(rigidBody.velocity.magnitude);
    }
}
                  