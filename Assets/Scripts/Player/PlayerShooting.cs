using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField]private PlayerWeapon[] weapons;
        
        public void OnShoot(InputValue value)
        {
            ShootWeapon();
        }

        private void ShootWeapon()
        {
            foreach (var weapon in weapons)
            {
                weapon.Fire();
            }
        }
    }
}
