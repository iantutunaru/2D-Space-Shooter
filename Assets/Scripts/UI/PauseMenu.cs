using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        public static event Action ResumeGame;
        
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
        }
    
        private void OnEnable()
        {
            Player.PlayerHealth.GameOver += GameOver;
        }

        private void OnDisable()
        {
            Player.PlayerHealth.GameOver -= GameOver;
        }
    
        public void Resume()
        {
            ResumeGame?.Invoke();
        }

        public void Pause()
        {
            Cursor.visible = true;
            
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers("UI");
            
            pauseMenu.SetActive(true);
        }

        public void Unpause()
        {
            Cursor.visible = false;
            
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers("Player");
            
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
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
            PlayerManager.Instance.ChangeControlSchemeForAllPlayers("UI");
            
            Cursor.visible = true;
            
            GameUI.Instance.gameObject.SetActive(false);
            
            scoreText.text = "You score is:" + Environment.NewLine + ScoreManager.Instance.GetScore() + " points";
            
            gameOverMenu.SetActive(true);
        }
    }
}
