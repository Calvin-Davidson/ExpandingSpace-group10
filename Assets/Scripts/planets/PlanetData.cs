using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    [SerializeField] private float PullStrenght = 0.8f;
    [SerializeField] private bool hasCollisionWithPlayer = false;
    [SerializeField] private bool attractPlayer = false;

    private List<Vector2> CircleWalkables = new List<Vector2>();

    [SerializeField] GameObject DebugCircle;
    
    public float getPullStrenght()
    {
        return this.PullStrenght;
    }

    public void setHasPlayerCollision(bool value)
    {
        this.hasCollisionWithPlayer = value;
    }

    public bool hasPlayerOnIt()
    {
        return this.hasCollisionWithPlayer;
    }
}