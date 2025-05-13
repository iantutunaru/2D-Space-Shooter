using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : Movement.Movement
    {
        [SerializeField] private float topScreenBoundsYPosition = 13.2f;
        
        [Header("Enemy References")]
        [SerializeField] private EnemyHealth enemyHealth;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (transform.position.y <= topScreenBoundsYPosition)
            {
                enemyHealth.CanBeDamaged = true;
            }    
        }
    }
}
