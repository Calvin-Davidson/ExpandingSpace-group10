using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingOnCollision : MonoBehaviour
{
    private PlanetData _planetData;

    private void Start()
    {
        _planetData = GetComponentInParent<PlanetData>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.name == "Player" || other.gameObject.tag == "Player")
            {
                _planetData.setHasPlayerCollision(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.tag == "Player")
        {
            _planetData.setHasPlayerCollision(false);
        }
    }
}