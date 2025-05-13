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
        
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemySounds enemySounds;
        
        [Header("Assets")]
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private DamageFlash damageFlash;
        
        private float _maxHealth = 1f;
        private float _currentHealth = 1f;
        
        private void OnEnable()
        {
            Returned = false;
            CanBeDamaged = false;
        }

        public void Init(float health)
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
                enemySounds.PlayDamageSound();
                damageFlash.CallDamageFlash();
            }
            else
            {
                enemySounds.PlayDeathSound();
                EnemyKilled();
            }
        }
        
        private void EnemyKilled()
        {
            OnEnemyDestroyed?.Invoke(enemy);
            enemySounds.PlayDeathSound();
            
            var spawnedDeathParticles = Managers.ObjectPoolManager.SpawnObject(deathParticles.gameObject, 
                transform.position, Quaternion.identity, Managers.ObjectPoolManager.PoolType.ParticleSystem);
                
            spawnedDeathParticles.GetComponent<ParticleSystem>().Play();
            
            Returned = true;
            Managers.ObjectPoolManager.ReturnObjectToPool(gameObject);
        }

        
    }
}