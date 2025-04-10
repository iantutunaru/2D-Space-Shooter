using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] PauseManager pauseManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject gameOverMenu;
    
    public void Resume()
    {
        pauseManager.Unpause();
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
        gameOverMenu.SetActive(false);
        Resume();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PlayAgain()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
