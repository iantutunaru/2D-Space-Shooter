using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private SoundFXManager soundFXManager;
    
    public ScoreManager ScoreManager { get { return scoreManager; } }
    public WaveManager WaveManager { get { return waveManager; } }
    public SpawnManager SpawnManager { get { return spawnManager; } }
    public SoundFXManager SoundFXManager { get { return soundFXManager; } }
}
