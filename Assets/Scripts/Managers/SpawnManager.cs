using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private GameManager gameManager;
        [SerializeField] private ScoreManager scoreManager;
    
        [Header("Line Formation Parameters")]
        [SerializeField] private int minEnemies = 1;
        [SerializeField] private int maxEnemies = 5;
        
        [Header("Obstacle Line Formation Parameters")]
        [SerializeField] private int minObstacleLineObstacles = 1;
        [SerializeField] private int maxObstacleLineObstacles = 2;
        
        [Header("Large Asteroid Parameters")]
        [SerializeField] private GameObject largeObstacle;
    
        [Header("Shield Pickup Parameters")]
        [SerializeField] private GameObject shieldPickup;
        
        // "SP" stands for Spawn Point
        private const int SpsSinMovementMin = 0;
        private const int SpsSinMovementMax = 1;
        private const int SpObstacleLineMin = 2;
        private const int SpObstacleLineMax = 3;
        private const int SpsLargeObstacleMin = 4;
        private const int SpsLargeObstacleMax = 5;
        private const int SpsPickupSpawnMin = 6;
        private const int SpsPickupSpawnMax = 7;
    
        private float _minSinSpawnTransformX, _maxSinSpawnTransformX;
        private float _minAsteroidTransformX, _maxAsteroidTransformX;
        private float _minLargeAsteroidTransformX, _maxLargeAsteroidTransformX;
        private float _minShieldSpawnTransformX, _maxShieldSpawnTransformX;
        private float _transformY;
        private float _transformZ;

        private const int OutOfBoundsWave = 0;
        private const int LineFormationWave = 1;
        private const int AsteroidWave = 2;
        private const int LargeAsteroidWave = 3;
    
        public void Start()
        {
            SetTransforms();
        }

        private void SetTransforms()
        {
            _minSinSpawnTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsSinMovementMin).position.x;
            _maxSinSpawnTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsSinMovementMax).position.x;
        
            _minAsteroidTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpObstacleLineMin).position.x;
            _maxAsteroidTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpObstacleLineMax).position.x;
        
            _minLargeAsteroidTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsLargeObstacleMin).position.x;
            _maxLargeAsteroidTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsLargeObstacleMax).position.x;
        
            _minShieldSpawnTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsPickupSpawnMin).position.x;
            _maxShieldSpawnTransformX = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsPickupSpawnMax).position.x;
            
            _transformY = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsSinMovementMin).position.y;
            _transformZ = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpsSinMovementMax).position.z;
        }

        public void SpawnWave()
        {
            var waveType = ChooseWaveType();
        
            switch (waveType)
            {
                case LineFormationWave:
                    SpawnLineFormation();
                    break;
                case AsteroidWave:
                    SpawnAsteroids();
                    break;
                case LargeAsteroidWave:
                    SpawnLargeAsteroid();
                    break;
                case OutOfBoundsWave:
                    Debug.LogWarning("ERROR: Wave Type out of range.");
                    break;
            }
        }
    
        private static int ChooseWaveType()
        {
            return Random.Range(LineFormationWave, LargeAsteroidWave+1);
        }

        private void SpawnLineFormation()
        {
            var enemySpawnPoint = new Vector3(Random.Range(_minSinSpawnTransformX, _maxSinSpawnTransformX), 
                _transformY, _transformZ);
            
            FormationManager.Instance.CreateFormation(Random.Range(minEnemies, maxEnemies), 
                                                                                    enemySpawnPoint, false);
        }

        private void SpawnAsteroids()
        {
            var asteroidSpawnPoint = new Vector3(Random.Range(_minAsteroidTransformX, _maxAsteroidTransformX), 
                _transformY, _transformZ);
            
            FormationManager.Instance.CreateFormation(Random.Range(minObstacleLineObstacles, maxObstacleLineObstacles), 
                                                                                    asteroidSpawnPoint, true);
        }

        private void SpawnLargeAsteroid()
        {
            var largeAsteroidSpawnPoint = new Vector3(Random.Range(_minLargeAsteroidTransformX, 
                _maxLargeAsteroidTransformX), _transformY, _transformZ);
            var asteroidRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            var spawnedLargeAsteroid = ObjectPoolManager.SpawnObject(largeObstacle, largeAsteroidSpawnPoint, 
                asteroidRotation, ObjectPoolManager.PoolType.Enemy);
        }

        public void SpawnPickup()
        {
            SpawnShieldPickup();
        }

        private void SpawnShieldPickup()
        {
            var shieldSpawnPoint = new Vector3(Random.Range(_minShieldSpawnTransformX, _maxShieldSpawnTransformX), 
                _transformY, _transformZ);
        
            var newShieldPickup = ObjectPoolManager.SpawnObject(shieldPickup, shieldSpawnPoint, 
                Quaternion.identity, ObjectPoolManager.PoolType.Enemy);
        }
    }
}
