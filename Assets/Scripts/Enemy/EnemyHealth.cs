using System;
using Interfaces;
using Shaders;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        public static event Action<Enemy> OnEnemyDestroyed;
        
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemySounds enemySounds;
        
        [Header("Assets")]
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private DamageFlash damageFlash;
        
        private float _maxHealth = 1f;
        private float _currentHealth = 1f;
        private bool _returned = false;

        private void OnEnable()
        {
            _returned = false;
        }

        public void Init(float health)
        {
            _maxHealth = health;
            _currentHealth = _maxHealth;
        }
        
        public void Damage(float damage = 1)
        {
            if (_returned) return;
            
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
            
            _returned = true;
            Managers.ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}