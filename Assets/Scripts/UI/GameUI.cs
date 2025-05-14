using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        public static GameUI Instance;
    
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private ScoreManager scoreManager;
        
        private void Start()
        {
            Cursor.visible = false;
        }
    
        private void Awake()
        {
            if (Instance != null) return;
        
            Instance = this;
        }

        private void OnEnable()
        {
            scoreManager.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            scoreManager.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            SetScoreText(score);
        }

        private void SetScoreText(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
