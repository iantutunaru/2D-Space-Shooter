using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private const int SpPlayerSpawn = 8;

        public void InitPlayer(Player.Player player)
        {
            var playerSpawn = SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpPlayerSpawn);
            
            player.Init(playerSpawn);
        }
    }
}
