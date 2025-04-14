using Managers;
using UnityEngine;

namespace Pickups
{
    public class PickupMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float outOfBoundsPosition = -16f;

        private bool OutOfBounds => transform.position.y <= outOfBoundsPosition;

        private void FixedUpdate()
        {
            Vector2 position = transform.position;
        
            position.y -= movementSpeed * Time.fixedDeltaTime;

            if (OutOfBounds)
            {
                ObjectPoolManager.ReturnObjectToPool(this.gameObject);
            }
        
            transform.position = position;
        }
    }
}
