using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private ScoreManager scoreManager;
        
        [Header("Spawn Settings")]
        [SerializeField] private float normalSizedObjectOffset = 1.00f;
        [SerializeField] private float largeSizedObjectOffset = 2.00f;
        [SerializeField] private float sinMovementObjectOffset = 1.65f;
    
        [Header("Line Formation Parameters")]
        [SerializeField] private int minEnemies = 1;
        [SerializeField] private int maxEnemies = 5;
        
        [Header("Obstacle Line Formation Parameters")]
        [SerializeField] private int minObstacleLineObstacles = 1;
        [SerializeField] private int maxObstacleLineObstacles = 2;
        
        [Header("Large Asteroid Parameters")]
        [SerializeField] private GameObject largeObstacle;
    
        [Header("Pickup Parameters")]
        [SerializeField] private GameObject[] pickups;
        
        [Header("Spawn Points")]
        [SerializeField] private Transform spawnPointYAndZ;
        
        [Header("Game Canvas")]
        [SerializeField] private Canvas gameCanvas;
        
        private float _minSinSpawnTransformX, _maxSinSpawnTransformX;
        private float _minAsteroidTransformX, _maxAsteroidTransformX;
        private float _minLargeAsteroidTransformX, _maxLargeAsteroidTransformX;
        private float _minPickupSpawnTransformX, _maxPickupSpawnTransformX;
        private float _transformY;
        private float _maxScreenWidth;
        private float _minScreenWidth;
        
        private void Start()
        {
            SetWorldBounds();
            SetTransforms();
        }
        
        private void SetWorldBounds()
        {
            var totalWidth = gameCanvas.GetComponent<RectTransform>().rect.width/10;
            
            _maxScreenWidth = totalWidth/2;
            _minScreenWidth = _maxScreenWidth * -1;
        }

        private void SetTransforms()
        {
            _minSinSpawnTransformX = _minScreenWidth+sinMovementObjectOffset;
            _maxSinSpawnTransformX = _maxScreenWidth-sinMovementObjectOffset;
        
            _minAsteroidTransformX = _minScreenWidth;
            _maxAsteroidTransformX = _maxScreenWidth;
        
            _minLargeAsteroidTransformX = _minScreenWidth+largeSizedObjectOffset;
            _maxLargeAsteroidTransformX = _maxScreenWidth-largeSizedObjectOffset;
        
            _minPickupSpawnTransformX = _minScreenWidth+normalSizedObjectOffset;
            _maxPickupSpawnTransformX = _maxScreenWidth-normalSizedObjectOffset;
            
            _transformY = spawnPointYAndZ.position.y;
        }
        
        public void SpawnLineFormation()
        {
            var enemySpawnPoint = new Vector3(Random.Range(_minSinSpawnTransformX, _maxSinSpawnTransformX), 
                _transformY);
            
            FormationManager.Instance.CreateFormation(Random.Range(minEnemies, maxEnemies), 
                                                                                    enemySpawnPoint, false);
        }

        public void SpawnAsteroids()
        {
            var asteroidSpawnPoint = new Vector3(Random.Range(_minAsteroidTransformX, _maxAsteroidTransformX), 
                _transformY);
            
            FormationManager.Instance.CreateFormation(Random.Range(minObstacleLineObstacles, maxObstacleLineObstacles), 
                                                                                    asteroidSpawnPoint, true);
        }

        public void SpawnLargeAsteroid()
        {
            var largeAsteroidSpawnPoint = new Vector3(Random.Range(_minLargeAsteroidTransformX, 
                _maxLargeAsteroidTransformX), _transformY);
            
            var asteroidRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            
            ObjectPoolManager.SpawnObject(largeObstacle, largeAsteroidSpawnPoint, asteroidRotation, 
                ObjectPoolManager.PoolType.Obstacle);
        }

        public void SpawnPickup()
        {
            var pickupIndex = Random.Range(0, pickups.Length);
            
            var pickupSpawnPoint = new Vector3(Random.Range(_minPickupSpawnTransformX, _maxPickupSpawnTransformX), 
                _transformY);
        
            ObjectPoolManager.SpawnObject(pickups[pickupIndex], pickupSpawnPoint, Quaternion.identity, 
                ObjectPoolManager.PoolType.Pickup);
        }
    }
}