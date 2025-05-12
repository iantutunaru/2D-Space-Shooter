using System;
using Managers;
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
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers(_actionMapUI);
            
            PauseGame?.Invoke();
        }

        public void OnCloseMenu(InputValue value)
        {
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers(_actionMapNormalPlayerInput);
            
            ResumeGame?.Invoke();
        }
    }
}
