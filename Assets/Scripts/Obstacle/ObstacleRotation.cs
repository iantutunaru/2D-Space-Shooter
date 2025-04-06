using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10;

    private void FixedUpdate()
    {
        Quaternion rotation = transform.rotation;
        
        rotation.eulerAngles += new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        
        transform.rotation = rotation;
    }
}
