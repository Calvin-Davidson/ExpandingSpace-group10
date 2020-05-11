using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlanetAttractionCollider : MonoBehaviour
{
    private PlanetData _planetData;

    private void Start()
    {
        _planetData = GetComponentInParent<PlanetData>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.tag == "Player")
        {
            _planetData.setAttractPlayer(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.tag == "Player")
        {
            _planetData.setAttractPlayer(false);
            _planetData.setHasPlayerCollision(false);
        }
    }
}