using System;
using System.Collections;
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
        private List<Vector2> RayCastPositions = new List<Vector2>();
        private Vector3 lastPlayerPos = Vector3.zero;
        private Vector2 lastHit;

        private int Points = 128;
        [SerializeField] private float RaycastLenght = 10;
        private movement _movement;

        private bool Rotated = false;

        private void Start()
        {
            _movement = GetComponent<movement>();

            lastPlayerPos = transform.position;

            double slice = 2 * Math.PI / Points;
            for (int i = 0; i < Points; i++)
            {
                float angle = (float) slice * i;

                float newX = (transform.position.x + 35 * Mathf.Cos(angle));
                float newY = (transform.position.y + 35 * Mathf.Sin(angle));

                RayCastPositions.Add(new Vector3(newX, newY));
                Debug.DrawLine(transform.position, new Vector3(newX, newY, 0));
            }

            lastHit = Vector2.zero;
        }

        void Update()
        {
            lastHit = Vector2.zero;
            // Verkrijg waar ik heen moet roteren.


            float ClosestDistance = 1000;

            float diffX = lastPlayerPos.x - transform.position.x;
            float diffY = lastPlayerPos.y - transform.position.y;

            int closestI = -1;

            for (int i = 0; i < RayCastPositions.Count; i++)
            {
                RayCastPositions[i].Set(RayCastPositions[i].x - diffX, RayCastPositions[i].y - diffY);

                float newX = RayCastPositions[i].x;
                float newY = RayCastPositions[i].y;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(newX, newY, 0), RaycastLenght,
                    LayerMask.GetMask("Walkable"));

                // If it hits something...
                if (hit.collider && hit.collider.gameObject)
                {
                    Debug.DrawRay(transform.position, new Vector3(newX, newY, 0), Color.red);

                    float dist = Vector2.Distance(hit.point, transform.position);
                    if (dist < ClosestDistance)
                    {
                        ClosestDistance = dist;
                        closestI = i;
                        lastHit = hit.point;
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, new Vector3(newX, newY, 0), Color.blue);
                }
            }

            if (closestI != -1)
            {
                double rotationZ = ((double) 360 / Points) * closestI + 90;
                Debug.DrawRay(transform.position, RayCastPositions[closestI], Color.red);
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(new Vector3(0, 0, float.Parse(rotationZ.ToString()))), 50 * Time.deltaTime);

                if (!Rotated)
                {
                    Rotated = true;
                    _movement.Rotated = true;
                    StartCoroutine(timer());
                }
            }

            else
            {
                Rotated = false;
                transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));
            }
        }

        public Vector2 getLastHit()
        {
            return this.lastHit;
        }

        public IEnumerator timer()
        {
            yield return new WaitForSeconds(0.7f);
            _movement.Rotated = false;
        }
    }
    
}