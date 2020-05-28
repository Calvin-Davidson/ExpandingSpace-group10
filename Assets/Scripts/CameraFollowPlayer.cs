using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    [SerializeField] private PlanetGravity _planetGravity;
    

    // Makes the camera follow the player,
    // and makes the camera rotate.
    private void FixedUpdate()
    {
            Vector3 transPos = playerObj.transform.position;
            transPos.z = transform.position.z;
            transform.position = transPos;

            transform.rotation = Quaternion.Lerp(transform.rotation, playerObj.transform.rotation, 0.7f * Time.deltaTime);
    }
}
