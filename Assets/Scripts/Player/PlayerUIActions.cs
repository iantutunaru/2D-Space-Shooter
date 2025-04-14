using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerUIActions : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;

        private readonly string _actionMapUI = "UI";
        private readonly string _actionMapNormalPlayerInput = "Player";
        
        public void OnOpenMenu(InputValue value)
        {
            playerInput.SwitchCurrentActionMap(_actionMapUI);
            Actions.Actions.PauseGame();
        }

        public void OnCloseMenu(InputValue value)
        {
            playerInput.SwitchCurrentActionMap(_actionMapNormalPlayerInput);
            Actions.Actions.ResumeGame();
        }
    }
}
