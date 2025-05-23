using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private static readonly List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

        private GameObject _objectPoolEmptyHolder;
        
        private static GameObject _playersEmpty;
        private static GameObject _enemiesEmpty;
        private static GameObject _obstaclesEmpty;
        private static GameObject _pickupsEmpty;
        private static GameObject _projectilesEmpty;
        private static GameObject _particleSystemsEmpty;
        private static GameObject _audioSourcesEmpty;
        
        public enum PoolType
        {
            Player,
            Enemy,
            Obstacle,
            Pickup,
            Projectile,
            ParticleSystem,
            AudioSource,
            None
        }
        
        public static PoolType PoolingType;

        private void Awake()
        {
            SetupEmpties();
        }

        private void SetupEmpties()
        {
            _objectPoolEmptyHolder = new GameObject("Pooled Objects");
        
            _playersEmpty = new GameObject("Players");
            _playersEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
        
            _enemiesEmpty = new GameObject("Enemies");
            _enemiesEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
            
            _obstaclesEmpty = new GameObject("Obstacles");
            _obstaclesEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
            
            _pickupsEmpty = new GameObject("Pickup");
            _pickupsEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
        
            _projectilesEmpty = new GameObject("Projectiles");
            _projectilesEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
        
            _particleSystemsEmpty = new GameObject("Particle Effects");
            _particleSystemsEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
        
            _audioSourcesEmpty = new GameObject("Audio Sources");
            _audioSourcesEmpty.transform.SetParent(_objectPoolEmptyHolder.transform);
        }

        public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, 
            PoolType poolType = PoolType.None)
        {
            var pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);
            
            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
                ObjectPools.Add(pool);
            }
        
            var spawnableObject = pool.InactiveObjects.FirstOrDefault();

            if (spawnableObject == null)
            {
                var parentObject = SetParentObject(poolType);
            
                spawnableObject = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

                if (parentObject != null)
                {
                    spawnableObject.transform.SetParent(parentObject.transform);
                }
            }
            else
            {
                spawnableObject.transform.position = spawnPosition;
                spawnableObject.transform.rotation = spawnRotation;
                pool.InactiveObjects.Remove(spawnableObject);
                spawnableObject.SetActive(true);
            }
        
            return spawnableObject;
        }
    
        public static GameObject SpawnObject(GameObject objectToSpawn, Transform parentTransform)
        {
            var pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

            if (pool == null)
            {
                pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
                ObjectPools.Add(pool);
            }
        
            var spawnableObject = pool.InactiveObjects.FirstOrDefault();

            if (spawnableObject == null)
            {
                spawnableObject = Instantiate(objectToSpawn, parentTransform);
            }
            else
            {
                pool.InactiveObjects.Remove(spawnableObject);
                spawnableObject.SetActive(true);
            }
        
            return spawnableObject;
        }

        public static void ReturnObjectToPool (GameObject objectToReturn)
        {
            var goName = objectToReturn.name.Substring(0, objectToReturn.name.Length - 7);
        
            var pool = ObjectPools.Find(p => p.LookupString == goName);

            if (pool == null)
            {
                Debug.LogWarning("Trying to release an object that is not pooled: " + objectToReturn.name);
            }
            else
            {
                objectToReturn.SetActive(false);
                pool.InactiveObjects.Add(objectToReturn);
            }
        }

        private static GameObject SetParentObject(PoolType poolType)
        {
            return poolType switch
            {
                PoolType.Player => _playersEmpty,
                PoolType.Enemy => _enemiesEmpty,
                PoolType.Obstacle => _obstaclesEmpty,
                PoolType.Pickup => _pickupsEmpty,
                PoolType.Projectile => _projectilesEmpty,
                PoolType.ParticleSystem => _particleSystemsEmpty,
                PoolType.AudioSource => _audioSourcesEmpty,
                PoolType.None => null,
                _ => null
            };
        }
    }

    public class PooledObjectInfo
    {
        public string LookupString;
        public readonly List<GameObject> InactiveObjects = new List<GameObject>();
    }
}