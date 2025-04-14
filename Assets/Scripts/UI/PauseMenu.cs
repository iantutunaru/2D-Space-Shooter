using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private TextMeshProUGUI scoreText;
    
        public static PauseMenu Instance;
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        
            Actions.Actions.GameOver += GameOver;
        }
    
        private void OnEnable()
        {
            Actions.Actions.GameOver += GameOver;
        }

        private void OnDisable()
        {
            Actions.Actions.GameOver -= GameOver;
        }

        private void OnDestroy()
        {
            Actions.Actions.GameOver -= GameOver;
        }
    
        public void Resume()
        {
            Actions.Actions.ResumeGame();
        }

        public void Pause()
        {
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }

        public void Unpause()
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            Cursor.visible = false;
        }

        public void OpenSettings()
        {
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void CloseSettings()
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }

        public void QuitGame()
        {
            Resume();
            SceneManager.LoadScene("MainMenuScene");
        }

        public void PlayAgain()
        {
            gameOverMenu.SetActive(false);
            SceneManager.LoadScene("GameScene");
        }

        private void GameOver()
        {
            Cursor.visible = true;
            GameUI.Instance.gameObject.SetActive(false);
            scoreText.text = "You score is:" + System.Environment.NewLine + ScoreManager.Instance.GetScore() + " points";
            gameOverMenu.SetActive(true);
        }
    }
}
