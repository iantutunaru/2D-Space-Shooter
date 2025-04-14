using System;

namespace Actions
{
    public static class Actions
    {
        // Player Manager Actions
        public static Action<Player.Player> NewPlayerJoined;
    
        // Player Actions
        public static Action<float> HealthChanged;
        public static Action<float> MaxHealthChanged;
    
        // Enemy Actions
        public static Action<Enemy.Enemy> OnEnemyDestroyed;
    
        // Game State Actions
        public static Action GameOver;
        public static Action PauseGame;
        public static Action ResumeGame;
    }
}