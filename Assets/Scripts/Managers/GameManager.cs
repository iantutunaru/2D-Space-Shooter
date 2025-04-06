using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private SpawnManager spawnManager;
    
    public ScoreManager ScoreManager { get { return scoreManager; } }
    public WaveManager WaveManager { get { return waveManager; } }
    public SpawnManager SpawnManager { get { return spawnManager; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
