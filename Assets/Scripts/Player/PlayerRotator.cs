using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private LayerMask CanHit;
        private Camera mainCam;
        private PlanetGravity _planetGravity;

        private List<Rotation_prop> _rotationProps = new List<Rotation_prop>();

        private Rotation_prop _closest_rotationProp;

        private float StartTime;
        private void Start()
        {
            StartTime = Time.time;
            mainCam = Camera.main;
            _planetGravity = GetComponent<PlanetGravity>();

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Rotation_prop"))
            {
                Rotation_prop rp = obj.GetComponent<Rotation_prop>();
                if (rp != null)
                {
                    _rotationProps.Add(rp);
                }
                else
                {
                    Debug.LogWarning("Gameobject " + obj.name + " is een rotation prop maar heeft niet de script!");
                }
            }
        }

        private void Update()
        {
            // Verkrijgt de rotation prop die het closest is.
            Rotation_prop tempRot = null;
            if (_rotationProps.Count != 0)
            {
                for (int i = 0; i < _rotationProps.Count; i++)
                {
                    _rotationProps[i].GetComponent<MeshRenderer>().material.color = Color.blue;
                    if (tempRot == null)
                    {
                        tempRot = _rotationProps[i];
                    }
                    else
                    {
                        float Distance = Vector2.Distance(_rotationProps[i].getPos(), transform.position);

                        if (Vector2.Distance(tempRot.getPos(), transform.position) >= Distance && Distance < 10.5f)
                        {
                            tempRot = _rotationProps[i];
                        }
                    }
                }
            }

            if (tempRot != null && Vector2.Distance(tempRot.getPos(), transform.position) < 10.5f)
            {
                _closest_rotationProp = tempRot;
            }
            else
            {
                Debug.Log( Vector2.Distance(tempRot.getPos(), transform.position));
                return;
            }

            Debug.Log(_closest_rotationProp.getVectorRotation());
            // transform.rotation = Quaternion.Euler(UnityEngine.Vector3.Lerp(transform.eulerAngles,
            //     _closest_rotationProp.getVectorRotation(), 0.1f * Time.deltaTime));

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation,
                    Quaternion.Euler(_closest_rotationProp.getVectorRotation()), 360);

            //float time = (Time.time - StartTime) / 1f;
            // float time = 2;
            // transform.rotation = Quaternion.Euler(Vector3.Slerp(transform.rotation.eulerAngles, _closest_rotationProp.getVectorRotation(), time));
            //
            _closest_rotationProp.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}