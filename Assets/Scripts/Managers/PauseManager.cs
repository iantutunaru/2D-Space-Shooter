using Player;
using UI;
using UnityEngine;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        private bool _gamePaused;
        
        private void OnEnable()
        {
            PlayerUIActions.PauseGame += Pause;
            PlayerUIActions.ResumeGame += Unpause;
            PauseMenu.ResumeGame += Unpause;
        
            _gamePaused = false;
        }

        private void OnDisable()
        {
            PlayerUIActions.PauseGame -= Pause;
            PlayerUIActions.ResumeGame -= Unpause;
            PauseMenu.ResumeGame -= Unpause;
        }
    
        private void Pause()
        {
            if (_gamePaused) return;

            PauseMenu.Instance.Pause();
            
            Time.timeScale = 0f;
            _gamePaused = true;
        }

        private void Unpause()
        {
            if (!_gamePaused) return;

            PauseMenu.Instance.Unpause();
            
            Time.timeScale = 1f;
            _gamePaused = false;
        }
    }
}
