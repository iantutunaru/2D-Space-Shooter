using UnityEngine;

namespace Pickups
{
    public class PickupSinMovePattern : MonoBehaviour
    {
        [SerializeField] private float amplitude = 2;
        [SerializeField] private float frequency = 0.5f;
        [SerializeField] private bool inverted = false;

        private float _sinCenterX;

        private void Start()
        {
            _sinCenterX = transform.position.x;
        }
    
        private void FixedUpdate()
        {
            Vector2 position = transform.position;
        
            var sinPattern = Mathf.Sin(position.y * frequency) * amplitude;

            if (inverted)
            {
                sinPattern *= -1;
            }
        
            position.x = _sinCenterX + sinPattern;
        
            transform.position = position;
        }
    }
}
