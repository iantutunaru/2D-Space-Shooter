using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();

        if (projectile != null)
        {
            if (projectile.isEnemy())
            {
                if (player.CanBeDestroyed())
                {
                    Destroy(this.gameObject);
                }
                
                Destroy(projectile.gameObject);
            }
            
        }
        
        Pickup pickup = collision.GetComponent<Pickup>();

        if (pickup != null)
        {
            if (pickup.IsShield)
            {
                if (player.CanBeDestroyed())
                {
                    player.TurnShieldOn();
                }
                
                Destroy(pickup.gameObject);
            }
        }
    }
}
