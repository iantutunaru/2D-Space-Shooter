using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.up;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private bool enemy = false; 
    [SerializeField] private float timeUntilDestruction = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeUntilDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        
        position += velocity * Time.fixedDeltaTime;
        
        transform.position = position;
    }

    public bool isEnemy()
    {
        return enemy;
    }
}
