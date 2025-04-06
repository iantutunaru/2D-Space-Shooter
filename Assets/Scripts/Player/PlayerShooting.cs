using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Action<bool> Fire;
    
    private bool _gunFired;
    private PlayerWeapon[] _weapons;

    private void Start()
    {
        _weapons = transform.GetComponentsInChildren<PlayerWeapon>();
    }
    
    public void OnShoot(InputValue value)
    {
        _gunFired = value.isPressed;
    }

    private void Update()
    {
        if (_gunFired)
        {
            _gunFired = false;
            
            foreach (PlayerWeapon weapon in _weapons)
            {
                weapon.Fire();
                
            }
        }
    }
}
