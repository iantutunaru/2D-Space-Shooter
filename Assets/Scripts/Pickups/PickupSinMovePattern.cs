using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSinMovePattern : MonoBehaviour
{
    [SerializeField] private float amplitude = 2;
    [SerializeField] private float frequency = 0.5f;
    [SerializeField] private bool inverted = false;

    private float sinCenterX;

    void Start()
    {
        sinCenterX = transform.position.x;
    }
    
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        
        float sinPattern = Mathf.Sin(position.y * frequency) * amplitude;

        if (inverted)
        {
            sinPattern *= -1;
        }
        
        position.x = sinCenterX + sinPattern;
        
        transform.position = position;
    }
}
