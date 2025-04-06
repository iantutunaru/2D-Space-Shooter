using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupManager : MonoBehaviour
{
    [SerializeField] private PlayerShield playerShield;

    public void TurnShieldOn()
    {
        playerShield.ToggleShield();
    }
}
