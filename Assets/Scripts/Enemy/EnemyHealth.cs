using System;
using Interfaces;
using Shaders;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable, IPoolReturnable
    {
        public static event Action<Enemy> OnEnemyDestroyed;
        public bool Returned { get; set; }
        public bool CanBeDamaged { get; set; }
        
        [SerializeField] private int health = 1;
        
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private Sounds.Sounds sounds;
        
        [Header("Assets")]
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private DamageFlash damageFlash;
        
        private float _maxHealth = 1f;
        private float _currentHealth = 1f;
        
        private void OnEnable()
        {
            ResetHealth();
            
            Returned = false;
            CanBeDamaged = false;
        }

        private void ResetHealth()
        {
            _maxHealth = health;
            _currentHealth = _maxHealth;
        }
        
        public void Damage(float damage = 1)
        {
            if (Returned) return;
            
            if (!CanBeDamaged) return;
            
            DealDamage(damage);
        }

        private void DealDamage(float damage)
        {
            if (_currentHealth > damage)
            {
                _currentHealth -= damage;
                sounds.PlayDamageSound();
                damageFlash.CallDamageFlash();
            }
            else
            {
                EnemyKilled();
            }
        }
        
        private void EnemyKilled()
        {
            OnEnemyDestroyed?.Invoke(enemy);
            
            var spawnedDeathParticles = Managers.ObjectPoolManager.SpawnObject(deathParticles.gameObject, 
                transform.position, Quaternion.identity, Managers.ObjectPoolManager.PoolType.ParticleSystem);
            
            spawnedDeathParticles.GetComponent<ParticleSystem>().Play();
            sounds.PlayDeathSound();
            
            Returned = true;
            Managers.ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}