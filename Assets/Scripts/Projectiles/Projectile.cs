using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.up;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private bool enemy = false; 
    [SerializeField] private float timeUntilDestruction = 3;
    [SerializeField] private ParticleSystem projectileTrail;
    
    private Coroutine _returnToPoolTimerCoroutine;
    
    // Start is called before the first frame update
    void Awake()
    {

        //Destroy(gameObject, timeUntilDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
        if (projectileTrail != null)
        {
            GameObject spawnedProjectileTrail = ObjectPoolManager.SpawnObject(projectileTrail.gameObject, transform.position, Quaternion.identity, ObjectPoolManager.PoolType.ParticleSystem);
            spawnedProjectileTrail.GetComponent<ParticleSystem>().Play();
        }
    }

    private IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= timeUntilDestruction)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        
        position += velocity * Time.fixedDeltaTime;
        
        transform.position = position;
    }

    public bool isEnemy()
    {
        return enemy;
    }
}
