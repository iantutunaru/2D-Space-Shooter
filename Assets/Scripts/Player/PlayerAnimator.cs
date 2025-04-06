using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int FMoveSpeed = Animator.StringToHash("f_moveSpeed");
    
    [SerializeField] private Animator animator;

    public void setMoveSpeed(float speed)
    {
        animator.SetFloat(FMoveSpeed, speed);
    }
}
