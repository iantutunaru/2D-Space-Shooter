using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float outOfBoundsPosition = -16f;

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        
        position.y -= movementSpeed * Time.fixedDeltaTime;

        if (position.y <= outOfBoundsPosition)
        {
            Destroy(this.gameObject);
        }
        
        transform.position = position;
    }
}
