using UnityEngine;

namespace Obstacle
{
    public class ObstacleRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 10;

        private void FixedUpdate()
        {
            var rotation = transform.rotation;
        
            rotation.eulerAngles += new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        
            transform.rotation = rotation;
        }
    }
}