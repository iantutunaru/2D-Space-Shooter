using Interfaces;
using Managers;
using Projectiles;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour, IFireable
    {
        [SerializeField] private float reloadTime = 2;
    
        [Header("Weapon assets")]
        [SerializeField] protected Projectile projectile;
        [SerializeField] protected Sounds.Sounds sounds;

        protected bool WeaponReloaded;
        private float _currentReloadTimer;
        
        private void OnEnable()
        {
            WeaponReloaded = true;
            _currentReloadTimer = 0;
        }
        
        protected bool Reload()
        {
            if (_currentReloadTimer < reloadTime)
            {
                _currentReloadTimer += Time.deltaTime;
            }
            else
            {
                _currentReloadTimer = 0;
                
                return true;
            }
            
            return false;
        }

        public void Fire()
        {
            sounds.PlayShootingSounds();
            ObjectPoolManager.SpawnObject(projectile.gameObject, transform.position, Quaternion.identity, 
                                                                            ObjectPoolManager.PoolType.Projectile);

            WeaponReloaded = false;
        }
    }
}
