using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private const int SpPlayerSpawn = 8;
    
        private void Awake()
        {
            Actions.Actions.NewPlayerJoined += SetNewPlayerStartingPosition;
        }

        private void OnEnable()
        {
            Actions.Actions.NewPlayerJoined += SetNewPlayerStartingPosition;
        }

        private void OnDisable()
        {
            Actions.Actions.NewPlayerJoined -= SetNewPlayerStartingPosition;
        }
        
        private void OnDestroy()
        {
            Actions.Actions.NewPlayerJoined -= SetNewPlayerStartingPosition;
        }
    
        private void SetNewPlayerStartingPosition(Player.Player newPlayer)
        {
            newPlayer.Init(SpawnPoints.SpawnPoints.Instance.GetSpawnPoint(SpPlayerSpawn));
        }
    }
}
