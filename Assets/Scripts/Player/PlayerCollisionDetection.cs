using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerSounds playerSounds;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();

        if (projectile != null)
        {
            if (projectile.isEnemy())
            {
                if (player.CanBeDestroyed())
                {
                    playerSounds.PlayDeathSound();
                    player.GameOver();
                    //Destroy(this.gameObject);
                }
                
                ObjectPoolManager.ReturnObjectToPool(projectile.gameObject);
                //Destroy(projectile.gameObject);
            }
            
        }

        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            if (player.CanBeDestroyed())
            {
                playerSounds.PlayDeathSound();
                player.GameOver();
            }
        }
        
        Pickup pickup = collision.GetComponent<Pickup>();

        if (pickup != null)
        {
            if (pickup.IsShield)
            {
                if (player.CanBeDestroyed())
                {
                    playerSounds.PlayShieldSound();
                    player.TurnShieldOn();
                }
                
                ObjectPoolManager.ReturnObjectToPool(pickup.gameObject);
                //Destroy(pickup.gameObject);
            }
        }
    }
}
