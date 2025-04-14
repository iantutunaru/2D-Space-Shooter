using Managers;
using Projectiles;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private bool autoFire = true;
        [SerializeField] private float fireRate = 0.5f;
    
        [Header("Weapon assets")]
        [SerializeField] private Projectile projectile;
        [SerializeField] private WeaponSounds weaponSounds;
    
        private float _fireRateTimer = 0f;
    
        private void Update()
        {
            if (!autoFire) return;
        
            if (_fireRateTimer >= fireRate)
            {
                Fire();
                _fireRateTimer = 0f;
            }
            else
            {
                _fireRateTimer += Time.deltaTime;
            }
        }

        private void Fire()
        {
            weaponSounds.PlayShootingSounds();
            ObjectPoolManager.SpawnObject(projectile.gameObject, transform.position, Quaternion.identity, 
                                                                            ObjectPoolManager.PoolType.Projectile);
        }
    }
}
