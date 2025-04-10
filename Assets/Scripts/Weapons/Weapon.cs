using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private bool autoFire = false;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float delay = 0.0f;
    [SerializeField] private float fireRateTimer = 0f;
    [SerializeField] private float delayTimer = 0f;
    [SerializeField] private WeaponSounds weaponSounds;
    
    void Update()
    {
        if (autoFire)
        {
            if (delayTimer >= delay)
            {
                if (fireRateTimer >= fireRate)
                {
                    Fire();
                    fireRateTimer = 0f;
                }
                else
                {
                    fireRateTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Fire()
    {
        weaponSounds.PlayShootingSounds();
        ObjectPoolManager.SpawnObject(projectile.gameObject, transform.position, Quaternion.identity, ObjectPoolManager.PoolType.Projectile);
        //GameObject firedProjectile = Instantiate(projectile.gameObject, transform.position, Quaternion.identity);
    }
}
