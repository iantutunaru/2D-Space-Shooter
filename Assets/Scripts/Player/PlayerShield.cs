using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private GameObject playerShield;
    [SerializeField] private float shieldTimerLimit = 10;
    [SerializeField] private Player player;
    
    private float _shieldTimer = 0;
    private bool _isShieldActive = false;
    
    public void Update()
    {
        ShieldTimeLimit();
    }

    private void ShieldTimeLimit()
    {
        if (_shieldTimer >= shieldTimerLimit && _isShieldActive)
        {
            ToggleShield();
        }
        else
        {
            _shieldTimer += Time.deltaTime;
        }
    }
    
    public void ToggleShield()
    {
        if (playerShield.activeSelf == false)
        {
            playerShield.SetActive(true);
            _shieldTimer = 0;
            _isShieldActive = true;
        }
        else
        {
            _shieldTimer = 0;
            _isShieldActive = false;
            player.TurnShieldOff();
            playerShield.SetActive(false);
        }
    }
}
