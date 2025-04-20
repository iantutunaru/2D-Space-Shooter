using UI;
using UnityEngine;

namespace Managers
{
    public class PauseManager : MonoBehaviour
    {
        private bool _gamePaused;
    
        private void Start()
        {
            _gamePaused = false;
        }

        private void OnEnable()
        {
            Actions.Actions.PauseGame += Pause;
            Actions.Actions.ResumeGame += Unpause;
        
            _gamePaused = false;
        }

        private void OnDisable()
        {
            Actions.Actions.PauseGame -= Pause;
            Actions.Actions.ResumeGame -= Unpause;
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
