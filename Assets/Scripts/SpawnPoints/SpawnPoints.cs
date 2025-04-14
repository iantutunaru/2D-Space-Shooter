using System.Collections.Generic;
using UnityEngine;

namespace SpawnPoints
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
    
        public static SpawnPoints Instance;
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
    
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

        public Transform GetSpawnPoint(int index)
        {
            switch (index)
            {
                case SpsSinMovementMin:
                    return spawnPoints[0];
                case SpsSinMovementMax:
                    return spawnPoints[1];
                case SpObstacleLineMin:
                    return spawnPoints[2];
                case SpObstacleLineMax:
                    return spawnPoints[3];
                case SpsLargeObstacleMin:
                    return spawnPoints[4];
                case SpsLargeObstacleMax:
                    return spawnPoints[5];
                case SpsPickupSpawnMin:
                    return spawnPoints[6];
                case SpsPickupSpawnMax:
                    return spawnPoints[7];
                case SpPlayerSpawn:
                    return spawnPoints[8];
                default:
                    Debug.LogWarning("ERROR: Spawn point transform index is out of range.");
                    return null;
            }
        }
    }
}
