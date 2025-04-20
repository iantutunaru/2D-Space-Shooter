using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerUIActions : MonoBehaviour
    {
        public static event Action PauseGame;
        public static event Action ResumeGame;
        
        [SerializeField] private PlayerInput playerInput;

        private readonly string _actionMapUI = "UI";
        private readonly string _actionMapNormalPlayerInput = "Player";
        
        public void OnOpenMenu(InputValue value)
        {
            playerInput.SwitchCurrentActionMap(_actionMapUI);
            
            PauseGame?.Invoke();
        }

        public void OnCloseMenu(InputValue value)
        {
            playerInput.SwitchCurrentActionMap(_actionMapNormalPlayerInput);
            
            ResumeGame?.Invoke();
        }
    }
}
