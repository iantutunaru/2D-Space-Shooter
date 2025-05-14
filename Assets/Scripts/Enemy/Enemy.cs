using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int scoreGain;
        
        public int GetScoreForKill()
        {
            return scoreGain;
        }
    }
}
