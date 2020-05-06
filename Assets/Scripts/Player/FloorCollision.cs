using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    private movement mv;

    private void Start()
    {
        mv = GetComponentInParent<movement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("floor collision");
        mv.jumpCount = 0;
    }
}
