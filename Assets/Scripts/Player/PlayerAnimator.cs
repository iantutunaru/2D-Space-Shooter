using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int FMoveSpeed = Animator.StringToHash("f_moveSpeed");
        private static readonly int FHealth = Animator.StringToHash("f_health");
    
        [Header("Player References")]
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private Animator playerEngineAnimator;

        public void SetMoveSpeed(float speed)
        {
            playerEngineAnimator.SetFloat(FMoveSpeed, speed);
        }

        public void SetHealth(float health)
        {
            playerAnimator.SetFloat(FHealth, health);
        }
    }
}
