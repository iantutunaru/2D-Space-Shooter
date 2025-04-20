using System;
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
    
        private Canvas _scoreCanvas;

        public void Init(ScoreManager newScoreManager)
        {
            scoreManager = newScoreManager;
            
            scoreManager.ScoreChanged += OnScoreChanged;
        }
    
        private void Awake()
        {
            if (Instance != null) return;
        
            Instance = this;
            _scoreCanvas = this.gameObject.GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            if (scoreManager == null)
            {
                return;
            }
            
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

        public void SetCanvasCamera(Camera newCanvasCamera)
        {
            _scoreCanvas.worldCamera = newCanvasCamera;
        }

        public void SetScoreText(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
