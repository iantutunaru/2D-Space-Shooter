using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool GamePaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Player player;

    public bool IsGamePaused()
    {
        return GamePaused;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        player.GetPlayerInput().SwitchCurrentActionMap("UI");
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        player.GetPlayerInput().SwitchCurrentActionMap("Player");
    }
}
