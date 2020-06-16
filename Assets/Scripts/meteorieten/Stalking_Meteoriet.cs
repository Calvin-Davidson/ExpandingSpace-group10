using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalking_Meteoriet : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float StalkDistance = 5;
    private Rigidbody2D _rigidbody2D;

    [SerializeField]private float _speed = 30f;
    [SerializeField]private float _rotateSpeed = 50f;

    private Vector2 direction = Vector2.zero;
    private void Start()
    {
        player = GameObject.Find("Player");
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        // Targets the player from the start.
        direction = (Vector2)player.transform.position - _rigidbody2D.position;
        direction.Normalize();
    }
    

    void FixedUpdate () {
        // If in range, change direction.
        if (Vector2.Distance(player.transform.position, transform.position) < StalkDistance)
        {
            direction = (Vector2)player.transform.position - _rigidbody2D.position;

            direction.Normalize();
        }
        
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        _rigidbody2D.angularVelocity = -rotateAmount * _rotateSpeed;

        _rigidbody2D.velocity = transform.up * _speed;   
    }
}