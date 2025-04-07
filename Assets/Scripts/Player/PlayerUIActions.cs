using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;

public class PlayerUIActions : MonoBehaviour
{
    
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private Player player;
    
    public void OnOpenMenu(InputValue value)
    {
        if (!pauseManager.IsGamePaused())
        {
            pauseManager.Pause();
        }
    }

    public void OnCloseMenu(InputValue value)
    {
        if (pauseManager.IsGamePaused())
        {
            pauseManager.Unpause();
        }
    }
}
