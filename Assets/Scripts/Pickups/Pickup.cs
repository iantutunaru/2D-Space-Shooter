using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupMovement pickupMovement;
    [SerializeField] private PickupSinMovePattern pickupSinMovePattern;
    [SerializeField] private bool shield = false;
    [SerializeField] private bool weapon = false;
    [SerializeField] private bool engine = false;
    
    public bool IsShield { get { return shield; } }
    public bool IsWeapon { get { return weapon; } }
    public bool IsEngine { get { return engine; } }
}
