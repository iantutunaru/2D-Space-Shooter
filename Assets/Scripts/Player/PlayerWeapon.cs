using Interfaces;
using Managers;
using Projectiles;
using UnityEngine;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour, IFireable
    {
        [SerializeField] private Projectile projectile;
        
        [Header("Weapon references")]
        [SerializeField] private Transform[] weaponLocations;
        [SerializeField] private Animator weaponAnimator;
        [SerializeField] private PlayerSounds playerWeaponSounds;

        private readonly string _gunShot = "WeaponShot";
    
        public void Fire()
        {
            playerWeaponSounds.PlayShootingSounds();
            
            ShootFromAllBarrels();
        
            weaponAnimator.SetTrigger(_gunShot);
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
