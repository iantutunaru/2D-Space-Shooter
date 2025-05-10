using System.Collections;
using Managers;
using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float timeUntilDestruction = 3;
    
        [Header("Projectile Assets")]
        [SerializeField] private ParticleSystem projectileTrail;
    
        [Header("Projectile Movement Variables")]
        [SerializeField] private Vector2 direction = Vector2.up;
        [SerializeField] private float speed;
        [SerializeField] private Vector2 velocity;
    
        [Header("Projectile Type Variables")]
        [SerializeField] private bool enemy = false; 
    
        private Coroutine _returnToPoolTimerCoroutine;
        
        private void FixedUpdate()
        {
            velocity = direction * speed;
            
            Vector2 position = transform.position;
        
            position += velocity * Time.fixedDeltaTime;
        
            transform.position = position;
        }

        private void OnEnable()
        {
            _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());

            CreateTrail();
        }

        private void CreateTrail()
        {
            if (projectileTrail == null) return;
            
            var spawnedProjectileTrail = ObjectPoolManager.SpawnObject(projectileTrail.gameObject, 
                transform.position, Quaternion.identity, ObjectPoolManager.PoolType.ParticleSystem);
            
            spawnedProjectileTrail.GetComponent<ParticleSystem>().Play();
        }

        private IEnumerator ReturnToPoolAfterTime()
        {
            var elapsedTime = 0f;

            while (elapsedTime <= timeUntilDestruction)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
        
        public bool IsEnemy()
        {
            return enemy;
        }
    }
}
