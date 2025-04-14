using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
{
    public class StartMenuController : MonoBehaviour

    {
        [SerializeField] private AudioSource buttonAudio;
    
        private readonly string _startButtonText = "StartButton";
        private readonly string _exitButtonText = "ExitButton";
        private UIDocument _document;
        private Button _startButton;
        private Button _exitButton;
        private List<Button> _menuButtons = new List<Button>();

        private void Awake()
        {
            _document = GetComponent<UIDocument>();
        
            _startButton = _document.rootVisualElement.Q(_startButtonText) as Button;
            _startButton?.RegisterCallback<ClickEvent>(OnStartButtonClicked);

            _exitButton = _document.rootVisualElement.Q(_exitButtonText) as Button;
            _exitButton?.RegisterCallback<ClickEvent>(OnExitButtonClicked);

            _menuButtons = _document.rootVisualElement.Query<Button>().ToList();

            foreach (var t in _menuButtons)
            {
                t.RegisterCallback<ClickEvent>(OnAllButtonClick);
            }
        }

        private void OnDisable()
        {
            _startButton.UnregisterCallback<ClickEvent>(OnStartButtonClicked);
            _exitButton.UnregisterCallback<ClickEvent>(OnExitButtonClicked);
        }

        private void OnStartButtonClicked(ClickEvent eClickEvent)
        {
            SceneManager.LoadScene("GameScene");
        }

        private void OnExitButtonClicked(ClickEvent eClickEvent)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        
            Application.Quit();
        }

        private void OnAllButtonClick(ClickEvent eClickEvent)
        {
            buttonAudio.Play();
        }
    }
}
