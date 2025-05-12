using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        
        private List<Player.Player> _players;
        private const int SpPlayerSpawn = 8;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
                _players = new List<Player.Player>();
            }
        }

        public void AddNewPlayer(Player.Player player)
        {
            _players.Add(player);
        }

        public bool RemovePlayer(Player.Player player)
        {
            return _players.Remove(player);
        }

        public void ChangeControlSchemeForAllPlayers(string controlScheme)
        {
            foreach (var player in _players)
            {
                player.ChangeControlScheme(controlScheme);
            }
        }
    }
}
