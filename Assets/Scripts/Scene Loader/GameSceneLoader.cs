using System.Collections.Generic;
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
            GameObject spawnedGameUI = Instantiate(gameUI);
            _instances.Add(spawnedGameUI);
            GameObject spawnedPauseMenuUI = Instantiate(pauseMenuUI);
            _instances.Add(spawnedPauseMenuUI);
            GameObject spawnedManagers = Instantiate(managers);
            _instances.Add(spawnedManagers);
            GameObject spawnedPlayer = Instantiate(player);
            _instances.Add(spawnedPlayer);

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
    }
}