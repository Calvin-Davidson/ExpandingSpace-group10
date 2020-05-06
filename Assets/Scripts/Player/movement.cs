using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] public int jumpCount = 0;
    [SerializeField] private float speed = 8;
    [SerializeField] private float JumpHeight = 8;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody2D.velocity = (new Vector2(-speed, _rigidbody2D.velocity.y));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (jumpCount < 2) 
            {
                _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, JumpHeight));
                jumpCount += 1;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, -speed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody2D.velocity = (new Vector2(speed, _rigidbody2D.velocity.y));
        }
    }
}