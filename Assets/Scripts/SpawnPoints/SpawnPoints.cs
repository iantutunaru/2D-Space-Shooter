using System.Collections.Generic;
using UnityEngine;

namespace SpawnPoints
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
    
        public static SpawnPoints Instance;
        
        // "SP" stands for Spawn Point
        private const int SpsSinMovementMin = 0;
        private const int SpsSinMovementMax = 1;
        private const int SpObstacleLineMin = 2;
        private const int SpObstacleLineMax = 3;
        private const int SpsLargeObstacleMin = 4;
        private const int SpsLargeObstacleMax = 5;
        private const int SpsPickupSpawnMin = 6;
        private const int SpsPickupSpawnMax = 7;
        private const int SpPlayerSpawn = 8;
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        public Transform GetSpawnPoint(int index)
        {
            switch (index)
            {
                case SpsSinMovementMin:
                    return spawnPoints[SpsSinMovementMin];
                case SpsSinMovementMax:
                    return spawnPoints[SpsSinMovementMax];
                case SpObstacleLineMin:
                    return spawnPoints[SpObstacleLineMin];
                case SpObstacleLineMax:
                    return spawnPoints[SpObstacleLineMax];
                case SpsLargeObstacleMin:
                    return spawnPoints[SpsLargeObstacleMin];
                case SpsLargeObstacleMax:
                    return spawnPoints[SpsLargeObstacleMax];
                case SpsPickupSpawnMin:
                    return spawnPoints[SpsPickupSpawnMin];
                case SpsPickupSpawnMax:
                    return spawnPoints[SpsPickupSpawnMax];
                case SpPlayerSpawn:
                    return spawnPoints[SpPlayerSpawn];
                default:
                    Debug.LogWarning("ERROR: Spawn point transform index is out of range.");
                    return null;
            }
        }
    }
}
