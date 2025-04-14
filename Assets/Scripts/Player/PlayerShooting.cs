using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        private PlayerWeapon[] _weapons;
        
        private void Awake()
        {
            _weapons = transform.GetComponentsInChildren<PlayerWeapon>();
        }
        
        public void OnShoot(InputValue value)
        {
            ShootWeapon();
        }

        private void ShootWeapon()
        {
            foreach (var weapon in _weapons)
            {
                weapon.Fire();
            }
        }
    }
}
