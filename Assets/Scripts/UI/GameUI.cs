using TMPro;
using UnityEngine;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        public static GameUI Instance;
    
        [SerializeField] private TextMeshProUGUI scoreText;
    
        private Canvas _scoreCanvas;
    
        private void Awake()
        {
            if (Instance != null) return;
        
            Instance = this;
            _scoreCanvas = this.gameObject.GetComponent<Canvas>();
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
