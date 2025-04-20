using System.Collections.Generic;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Loader
{
    public class GameSceneLoader : MonoBehaviour
    {
        [SerializeField] private new GameObject camera;
        [SerializeField] private GameObject globalLight;
        [SerializeField] private GameObject eventSystem;
        [SerializeField] private GameObject gameBackground;
        [SerializeField] private GameObject gameBorders;
        [SerializeField] private GameObject spawnPoints;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private GameObject managers;
        [SerializeField] private GameObject player;

        private List<GameObject> _instances;
    
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Cursor.visible = false;
            _instances = new List<GameObject>();

            GameObject spawnedCamera = Instantiate(camera);
            _instances.Add(spawnedCamera);
            GameObject spawnedGlobalLight = Instantiate(globalLight);
            _instances.Add(spawnedGlobalLight);
            GameObject spawnedEventSystem = Instantiate(eventSystem);
            _instances.Add(spawnedEventSystem);
            GameObject spawnedGameBackground = Instantiate(gameBackground);
            _instances.Add(spawnedGameBackground);
            GameObject spawnedGameBorders = Instantiate(gameBorders);
            _instances.Add(spawnedGameBorders);
            GameObject spawnedSpawnPoints = Instantiate(spawnPoints);
            _instances.Add(spawnedSpawnPoints);
            GameObject spawnedPauseMenuUI = Instantiate(pauseMenuUI);
            _instances.Add(spawnedPauseMenuUI);
            GameObject spawnedPlayer = Instantiate(player);
            _instances.Add(spawnedPlayer);

            var newPlayer = spawnedPlayer.GetComponent<Player.Player>();
            var managersObject = InitializeManagers(newPlayer);
            var scoreManager = managersObject.GetComponent<ScoreManager>();
            
            InitializeGameUi(scoreManager);

            GameUI.Instance.SetCanvasCamera(camera.GetComponent<Camera>());
        }
    
        private void OnDisable()
        {
            DestroyInstances();
            Cursor.visible = true;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnDestroy()
        {
            DestroyInstances();
            Cursor.visible = true;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void DestroyInstances()
        {
            foreach (var instance in _instances)
            {
                Destroy(instance);
            }
        }

        private GameObject InitializeManagers(Player.Player newPlayer)
        {
            var spawnedManagers = Instantiate(managers);
            var gameManager = spawnedManagers.GetComponent<GameManager>();
            
            gameManager.InitPlayer(newPlayer);

            _instances.Add(spawnedManagers);
            
            return spawnedManagers;
        }

        private void InitializeGameUi(ScoreManager scoreManager)
        {
            var gameUiObject = Instantiate(gameUI);
            var spawnedGameUI = gameUiObject.GetComponent<GameUI>(); 
            
            spawnedGameUI.Init(scoreManager);
            
            _instances.Add(gameUiObject);
        }
    }
}