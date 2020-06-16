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
        private Vector3 position;
        private bool doRayCasts = false;

        private void Start()
        {
            position = transform.position;
            _movement = GetComponent<movement>();

            lastPlayerPos = transform.position;


            // Make the circle around the player.
            double slice = 2 * Math.PI / Points;
            for (int i = 0; i < Points; i++)
            {
                float angle = (float) slice * i;

                float newX = (position.x + 35 * Mathf.Cos(angle));
                float newY = (position.y + 35 * Mathf.Sin(angle));

                RayCastPositions.Add(new Vector3(newX, newY));
                Debug.DrawLine(position, new Vector3(newX, newY, 0));
            }

            lastHit = Vector2.zero;
        }


        // Verkrijg waar ik heen moet roteren.
        void Update()
        {
            // Get the new position ~ transform is same as getComponent.
            position = transform.position;

            float closestDistance = 1000;

            // Calculates the distance between the last Player position.
            float diffX = lastPlayerPos.x - position.x;
            float diffY = lastPlayerPos.y - position.y;

            int closestI = -1;

            if (!doRayCasts) return;

            // Finds the closest walkable object. by raycasting a circle around the player
            for (int i = 0; i < RayCastPositions.Count; i++)
            {
                // Calculate the new RayCast positions.
                RayCastPositions[i].Set(RayCastPositions[i].x - diffX, RayCastPositions[i].y - diffY);
                float newX = RayCastPositions[i].x;
                float newY = RayCastPositions[i].y;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(newX, newY, 0), RaycastLenght,
                    LayerMask.GetMask("Walkable"));

                // If it hits something...
                if (hit.collider && hit.collider.gameObject)
                {
                    Debug.DrawRay(transform.position, new Vector3(newX, newY, 0), Color.red);

                    float dist = Vector2.Distance(hit.point, position);
                    if (dist < closestDistance)
                    {
                        closestDistance = dist;
                        closestI = i;
                        lastHit = hit.point;
                    }
                }
            }

            if (closestI != -1)
            {
                // Rotate to stand on the object in range.
                double rotationZ = ((double) 360 / Points) * closestI + 90;
                Debug.DrawRay(transform.position, RayCastPositions[closestI], Color.red);

                if (!Rotated)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation,
                        Quaternion.Euler(new Vector3(0, 0, (float) rotationZ)), 50 * Time.deltaTime);
                    
                    Rotated = true;
                    _movement.Rotated = true;
                    StartCoroutine(Timer());
                }
                else
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, (float) rotationZ)), 20 * Time.deltaTime);
                }
            }
            else
            {
                // If there is no object in range
                lastHit = Vector2.zero;
                Rotated = false;
                transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));
            }
        }

        public Vector2 GetLastHit()
        {
            return this.lastHit;
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(0.7f);
            _movement.Rotated = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "PlayerInAir" || other.gameObject.name == "AttractionSize")
            {
                doRayCasts = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.name == "PlayerInAir" || other.gameObject.name == "AttractionSize")
            {
                doRayCasts = false;
            }
        }
    }
}