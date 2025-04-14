using Shaders;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Enemy References")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private EnemySounds enemySounds;
        
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
        }

        public void DealDamage(float damage = 1f)
        {
            if (_currentHealth > damage)
            {
                _currentHealth -= damage;
                enemySounds.PlayDamageSound();
                _damageFlash.CallDamageFlash();
            }
            else
            {
                enemySounds.PlayDeathSound();
                EnemyKilled();
            }
        }
        
        private void EnemyKilled()
        {
            Actions.Actions.OnEnemyDestroyed(enemy);
            enemySounds.PlayDeathSound();
            Managers.ObjectPoolManager.ReturnObjectToPool(gameObject);
                
            var spawnedDeathParticles = Managers.ObjectPoolManager.SpawnObject(deathParticles.gameObject, 
                transform.position, Quaternion.identity, Managers.ObjectPoolManager.PoolType.ParticleSystem);
                
            spawnedDeathParticles.GetComponent<ParticleSystem>().Play();
        }
    }
}