using System;
using Interfaces;
using Shaders;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public static event Action<float> HealthChanged;
        public static event Action<float> MaxHealthChanged;
        
        [Header("Player References")]
        [SerializeField] private Player player;
        [SerializeField] private PlayerSounds playerSounds;
        [SerializeField] private PlayerAnimator playerAnimator;
        [Header("Assets")]
        [SerializeField] private ParticleSystem deathParticles;
        
        private float _maxHealth = 1f;
        private float _currentHealth = 1f;
        private DamageFlash _damageFlash;

        private void Start()
        {
            _damageFlash = GetComponent<DamageFlash>();
        }
    
        public void Init(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
            playerAnimator.SetHealth(_currentHealth);
            
            MaxHealthChanged?.Invoke(_currentHealth);
        }
        
        public void Damage(float damage = 1f)
        {
            if (player.CanBeDamaged())
            {
                DealDamage(damage);
            }
        }

        private void DealDamage(float damage)
        {
            if (_currentHealth > damage)
            {
                _currentHealth -= damage;
                
                HealthChanged?.Invoke(_currentHealth);
                
                playerSounds.PlayDamageSound();
                _damageFlash.CallDamageFlash();
                playerAnimator.SetHealth(_currentHealth);
            }
            else
            {
                playerSounds.PlayDeathSound();
                
                var spawnedDeathParticles = Managers.ObjectPoolManager.SpawnObject(deathParticles.gameObject, 
                    transform.position, Quaternion.identity, Managers.ObjectPoolManager.PoolType.ParticleSystem);
                
                spawnedDeathParticles.GetComponent<ParticleSystem>().Play();
                
                player.Die();
            }
        }
    }
}
