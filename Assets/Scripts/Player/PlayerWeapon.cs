using System;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private bool autoFire = false;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float delay = 0.0f;
    [SerializeField] private float fireRateTimer = 0f;
    [SerializeField] private float delayTimer = 0f;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private Animator animator;

    private String _gunShot = "WeaponShot";
    
    public void Fire()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject firedProjectile = Instantiate(projectile.gameObject, firePoint.position, Quaternion.identity);
        }
        
        animator.SetTrigger(_gunShot);
    }
}
