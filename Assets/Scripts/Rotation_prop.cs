using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_prop : MonoBehaviour
{
    private Vector3 position;
    [SerializeField] private Quaternion PlayerRotation;
    [SerializeField] private Vector3 rotation;
    private void Start()
    {
        this.position = transform.position;
    }

    public Vector3 getPos()
    {
        return this.position;
    }

    public Quaternion getPlayerRotation()
    {
        return this.PlayerRotation;
    }

    public Vector3 getVectorRotation()
    {
        return this.rotation;
    }
}
