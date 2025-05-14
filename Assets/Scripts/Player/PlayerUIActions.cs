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

        private const string ActionMapUI = "UI";
        private const string ActionMapNormalPlayerInput = "Player";

        public void OnOpenMenu(InputValue value)
        {
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers(ActionMapUI);
            
            PauseGame?.Invoke();
        }

        public void OnCloseMenu(InputValue value)
        {
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers(ActionMapNormalPlayerInput);
            
            ResumeGame?.Invoke();
        }
    }
}
