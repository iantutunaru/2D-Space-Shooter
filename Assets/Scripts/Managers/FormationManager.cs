using UnityEngine;

namespace Managers
{
    public class FormationManager : MonoBehaviour
    {
        public static FormationManager Instance;

        [SerializeField] private GameObject lineFormationEnemy;
        [SerializeField] private GameObject obstacleLineEnemy;

        [SerializeField] private int distanceBetweenLineFormationEnemies;
        [SerializeField] private int distanceBetweenObstacles;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        public void CreateFormation(int numberOfObjectsInFormation, Vector3 spawnPoint, bool isObstacle)
        {
            var nextPosition = spawnPoint;
            var nextObstacleRotation = RandomizeRotationForObstacles(isObstacle);
            var poolType = ChooseObjectPoolType(isObstacle);
            var objectToSpawn = ChooseObjectToSpawn(isObstacle);
            
            for (var i = 0; i < numberOfObjectsInFormation; i++)
            {
                var spawnedEnemy = ObjectPoolManager.SpawnObject(objectToSpawn, nextPosition, 
                                                                nextObstacleRotation, poolType);
            
                nextPosition = NextPosition(nextPosition, isObstacle);
                nextObstacleRotation = RandomizeRotationForObstacles(isObstacle);
            }
        }

        private ObjectPoolManager.PoolType ChooseObjectPoolType(bool isObstacle)
        {
            return isObstacle ? ObjectPoolManager.PoolType.Obstacle : ObjectPoolManager.PoolType.Enemy;
        }

        private GameObject ChooseObjectToSpawn(bool isObstacle)
        {
            return isObstacle ? obstacleLineEnemy : lineFormationEnemy;
        }

        private Quaternion RandomizeRotationForObstacles(bool isObstacle)
        {
            return isObstacle ? Quaternion.Euler(0, 0, Random.Range(0, 360)) : Quaternion.identity;
        }

        private Vector3 NextPosition(Vector3 oldPosition, bool isObstacle)
        {
            var newPosition = oldPosition;
            
            if (isObstacle)
            {
                newPosition += Vector3.right * distanceBetweenObstacles 
                               + Vector3.up * distanceBetweenObstacles;
            }
            else
            {
                newPosition += Vector3.up * distanceBetweenLineFormationEnemies;
            }

            return newPosition;
        }
    }
}