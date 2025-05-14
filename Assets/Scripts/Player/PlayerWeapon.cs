using Managers;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerWeapon : Weapon
    {
        [Header("Player Weapon References")]
        [SerializeField] private Transform[] weaponLocations;
        [SerializeField] private Animator weaponAnimator;
        
        private const string GunShot = "WeaponShot";
        private static readonly int WeaponShot = Animator.StringToHash(GunShot);

        private void FixedUpdate()
        {
            if (!WeaponReloaded)
            {
                WeaponReloaded = Reload();
            }
        }
        
        public new void Fire()
        {  
            if (!WeaponReloaded) return;
            
            sounds.PlayShootingSounds();
            
            ShootFromAllBarrels();
        
            weaponAnimator.SetTrigger(WeaponShot);
            
            WeaponReloaded = false;
        }

        private void ShootFromAllBarrels()
        {
            foreach (var firePoint in weaponLocations)
            {
                ObjectPoolManager.SpawnObject(projectile.gameObject, firePoint.position, Quaternion.identity, 
                    ObjectPoolManager.PoolType.Projectile);
            }
        }
    }
}
