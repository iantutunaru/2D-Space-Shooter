using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 1f;
        
        [Header("Player References")]
        [SerializeField] private Rigidbody2D playerRigidbody2D;
        [SerializeField] private PlayerAnimator playerAnimator;
    
        private Vector2 _movementInput;
        
        public void OnMove(InputValue value)
        {
            _movementInput = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            playerRigidbody2D.velocity = _movementInput * movementSpeed;
            
            playerAnimator.SetMoveSpeed(playerRigidbody2D.velocity.magnitude);
        }
    }
}
                  