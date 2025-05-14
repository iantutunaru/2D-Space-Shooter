using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        
        private List<Player.Player> _players;

        private const string ControlSchemeGame = "Player";

        private void Awake()
        {
            if (Instance != null) return;
            
            Instance = this;
                
            _players = new List<Player.Player>();
        }

        public void AddNewPlayerOnGameStart(Player.Player player)
        {
            _players.Add(player);
            ChangeControlSchemeForAllPlayers(ControlSchemeGame);
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
