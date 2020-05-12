using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private LayerMask CanHit;

        // private List<Rotation_prop> _rotationProps = new List<Rotation_prop>();
        // private Rotation_prop _closest_rotationProp;

        private List<Vector2> RayCastPositions = new List<Vector2>();
        private Vector3 lastPlayerPos = Vector3.zero;

        private GameObject debugObg;

        private int Points = 64;

        private void Start()
        {
            debugObg = GameObject.Find("DebugSphere");

            lastPlayerPos = transform.position;

            double slice = 2 * Math.PI / Points;
            for (int i = 0; i < Points; i++)
            {
                float angle = (float) slice * i;

                float newX = (transform.position.x + 50 * Mathf.Cos(angle));
                float newY = (transform.position.y + 50 * Mathf.Sin(angle));

                RayCastPositions.Add(new Vector3(newX, newY));
            }
        }

        void Update()
        {
            // Verkrijg waar ik heen moet roteren.

            Vector3 hitPoint = Vector3.zero;
            float ClosestDistance = 1000;

            float diffX = lastPlayerPos.x - transform.position.x;
            float diffY = lastPlayerPos.y - transform.position.y;

            int closestI = 0;

            for (int i = 0; i < RayCastPositions.Count; i++)
            {
                RayCastPositions[i].Set(RayCastPositions[i].x - diffX, RayCastPositions[i].y - diffY);

                float newX = RayCastPositions[i].x;
                float newY = RayCastPositions[i].y;

                //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(newX, newY, 0), Mathf.Infinity);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(newX, newY, 0), Mathf.Infinity,
                    LayerMask.GetMask("Walkable"));

                // If it hits something...
                if (hit.collider)
                {
                    //Debug.DrawRay(transform.position, new Vector3(newX, newY, 0), Color.red);

                    float dist = Vector2.Distance(hit.point, transform.position);
                    if (dist < ClosestDistance)
                    {
                        ClosestDistance = dist;
                        closestI = i;
                    }
                }
                else
                {
                    //Debug.DrawRay(transform.position, new Vector3(newX, newY, 0), Color.blue);
                }
            }

            debugObg.transform.position = hitPoint;

            print("ClosestI: " + closestI);
            print("Rotation: " + ((360 / 64) * closestI + 90));
            Debug.DrawRay(transform.position, RayCastPositions[closestI], Color.red);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, (360 / 64 * closestI + 90))), 10 * Time.deltaTime);
        }
    }
}