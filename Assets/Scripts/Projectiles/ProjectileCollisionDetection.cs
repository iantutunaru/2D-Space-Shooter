using System;
using Interfaces;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileCollisionDetection : MonoBehaviour
    {
        [SerializeField] private Projectile projectile;
        
        private bool _returned = false;

        private void OnEnable()
        {
            _returned = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_returned) return;
            
            if (CheckIfPlayerIsShotByPlayer(collision)) return;
            
            if (CheckIfEnemyIsShotByEnemy(collision)) return;
            
            DealDamageIfHitByProjectile(collision);
        }
        
        private void DealDamageIfHitByProjectile(Collider2D collision)
        {
            var damageableObject = collision.GetComponent<IDamageable>();
            
            damageableObject?.Damage();

            _returned = true;
            
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
        
        private bool CheckIfPlayerIsShotByPlayer(Collider2D collision)
        {
            var player = collision.GetComponent<Player.Player>();

            return !projectile.IsEnemy() && player != null;
        }

        private bool CheckIfEnemyIsShotByEnemy(Collider2D collision)
        {
            var enemy = collision.GetComponent<Enemy.Enemy>();

            return projectile.IsEnemy() && enemy != null;
        }
    }
}
