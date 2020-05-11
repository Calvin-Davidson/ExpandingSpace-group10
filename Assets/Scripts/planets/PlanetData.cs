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

    private void Start()
    {
        // Zorgt dat je mooi om de circle kan lopen.
        // int points = (int) transform.localScale.x * 10;
        // int offset = 0;
        // float radius = transform.localScale.x / 2;
        // double slice = 2 * Math.PI / points;
        // for (var i = 0; i < points; i++)
        // {
        //     float angle = (float) slice * i + offset;
        //
        //     var newX = (transform.position.x + radius * Mathf.Cos(angle));
        //     var newY = (transform.position.y + radius * Mathf.Sin(angle));
        //
        //     CircleWalkables.Add(new Vector2(newX, newY));
        //     Instantiate(DebugCircle, new Vector3(newX, newY, 0), quaternion.identity);
        // }
    }

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

    public void setAttractPlayer(bool value)
    {
        this.attractPlayer = value;
    }

    public bool getAttractPlayer()
    {
        return this.attractPlayer;
    }
}