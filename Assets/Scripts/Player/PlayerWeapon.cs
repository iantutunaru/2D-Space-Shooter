using System;
using Interfaces;
using Managers;
using Projectiles;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour, IFireable
    {
        [SerializeField] private Projectile projectile;
        [SerializeField] private float reloadTime = 1;
        
        [Header("Weapon references")]
        [SerializeField] private Transform[] weaponLocations;
        [SerializeField] private Animator weaponAnimator;
        [SerializeField] private PlayerSounds playerWeaponSounds;

        private bool _weaponReloaded;
        
        private float _currentReloadTimer;
        private readonly string _gunShot = "WeaponShot";

        private void OnEnable()
        {
            _weaponReloaded = false;
            _currentReloadTimer = reloadTime;
        }

        private void FixedUpdate()
        {
            if (_currentReloadTimer < reloadTime)
            {
                _currentReloadTimer += Time.deltaTime;
            }
            else
            {
                _weaponReloaded = true;
                _currentReloadTimer = 0;
            }
        }
        
        public void Fire()
        {
            if (!_weaponReloaded) return;
            
            playerWeaponSounds.PlayShootingSounds();
            
            ShootFromAllBarrels();
        
            weaponAnimator.SetTrigger(_gunShot);
            
            _weaponReloaded = false;
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
