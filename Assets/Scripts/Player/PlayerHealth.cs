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
        public static event Action GameOver;
        
        [SerializeField] private float health = 4f;
        [SerializeField] private bool canBeDamaged;
        
        [Header("Player References")]
        [SerializeField] private Player player;
        [SerializeField] private PlayerSounds playerSounds;
        [SerializeField] private PlayerAnimator playerAnimator;
        
        [Header("Assets")]
        [SerializeField] private ParticleSystem deathParticles;
        
        [Header("Testing Settings")]
        [SerializeField] private bool invincible = false;
        
        private float _maxHealth = 1f;
        private float _currentHealth = 1f;
        private DamageFlash _damageFlash;

        private void Start()
        {
            _damageFlash = GetComponent<DamageFlash>();
        }
    
        public void OnEnable()
        {
            _maxHealth = health;
            _currentHealth = _maxHealth;
            
            playerAnimator.SetHealth(_currentHealth);
            canBeDamaged = true;
            
            MaxHealthChanged?.Invoke(_currentHealth);
        }

        public void ToggleDamage()
        {
            canBeDamaged = !canBeDamaged;
        }

        public bool CanBeDamaged()
        {
            return canBeDamaged;
        }
        
        public void Damage(float damage = 1f)
        {
            if (canBeDamaged)
            {
                DealDamage(damage);
            }
        }
        
        private void DealDamage(float damage)
        {
            if (invincible) return;
            
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
                
                Die();
            }
        }
        
        private void Die()
        { 
            player.DisableMovementAndVisuals();

            GameOver?.Invoke();
        }
    }
}
