using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class StartScherm_Shipmovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    private RectTransform _transform;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        
    }


    // moves a object in and out of the start screen
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        if (transform.rotation.y == 0 && transform.position.x <= -280)
        {
            _transform.position =
                new Vector3(transform.position.x, UnityEngine.Random.Range(0, 300), transform.position.z);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        if (transform.rotation.y == 1 && transform.position.x >= 1250)
        {
            _transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.position =
                new Vector3(transform.position.x, UnityEngine.Random.Range(0, 300), transform.position.z);
        }
        
        
    }
}