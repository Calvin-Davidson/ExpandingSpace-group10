using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed = 0.5f;
    public float amplitude = 0.1f;

    public Vector2 tempPosition;

    private void Start()
    {
        tempPosition = transform.position;
    }

    private void FixedUpdate()
    {
        tempPosition.x += horizontalSpeed;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
}

