using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    [SerializeField] bool canBeDestroyed = false;
    [SerializeField] private float screenBoundsPosition = 13.2f;
    [SerializeField] private int scoreValue;
    
    private ScoreManager _scoreManager;

    public void SetScoreManager(ScoreManager scoreManager)
    {
        _scoreManager = scoreManager;
    }
    
    void Update()
    {
        if (transform.position.y <= screenBoundsPosition)
        {
            canBeDestroyed = true;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        
        Projectile projectile = collision.GetComponent<Projectile>();

        if (projectile != null)
        {
            if (!projectile.isEnemy())
            {
                _scoreManager.AddScore(scoreValue);
                Destroy(this.gameObject);
                Destroy(projectile.gameObject);
            }
        }
        
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            _scoreManager.AddScore(scoreValue);
            Destroy(this.gameObject);

            if (player.CanBeDestroyed())
            {
                Destroy(player.gameObject);
            }
        }
    }
}
