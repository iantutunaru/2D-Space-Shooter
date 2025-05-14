using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class StartMenuController : MonoBehaviour

    {
        [SerializeField] private AudioSource buttonAudio;
        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject settingsMenu;

        private void Start()
        {
            Cursor.visible = true;
        }
        
        public void OnStartButtonClicked()
        {
            PlayButtonSound();
            SceneManager.LoadScene("GameScene");
        }

        public void OnSettingsButtonClicked()
        {
            PlayButtonSound();
            startMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void OnExitButtonClicked()
        {
#if UNITY_EDITOR
            PlayButtonSound();
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        
            PlayButtonSound();
            Application.Quit();
        }

        public void OnBackButtonClicked()
        {
            PlayButtonSound();
            settingsMenu.SetActive(false);
            startMenu.SetActive(true);
        }

        private void PlayButtonSound()
        {
            buttonAudio.Play();
        }
    }
}
