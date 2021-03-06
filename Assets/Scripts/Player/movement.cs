﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class movement : MonoBehaviour
    {
        [SerializeField] private Animator _Player_Animator;

        [SerializeField] private ParticleSystem smoke_left_bottom;
        [SerializeField] private ParticleSystem smoke_right_bottom;
        [SerializeField] private ParticleSystem smoke_left_top;
        [SerializeField] private ParticleSystem smoke_right_top;

        [SerializeField] private float speed = 8;

        private Rigidbody2D _rigidbody2D;
        private PullToGround _pullToGround;

        public bool Rotated = false;

        private void Start()
        {
            _pullToGround = GetComponent<PullToGround>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;

            if (_pullToGround.getInAir())
            {
                InAirMovement();
            }
            else
            {
                onGroundMovement();
            }
            
            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                _Player_Animator.SetBool("walk", false);
                _Player_Animator.SetBool("idle", true);
            }
            if (!Input.GetKey(KeyCode.W)) _Player_Animator.SetBool("jump", false);
        }

        // When on ground we walk around objects.
        private void onGroundMovement()
        {
            var newVel = _rigidbody2D.velocity * Time.deltaTime;

            // movement up.
            if (Input.GetKey(KeyCode.W) && Rotated == false)
            {
                newVel = new Vector2(newVel.x + transform.up.x * speed * 1.3f,
                    newVel.y + transform.up.y * speed * 1.3f);
                
                _Player_Animator.SetBool("jump", true);
                _Player_Animator.SetBool("idle", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                newVel = new Vector2(newVel.x + -transform.right.x * speed, newVel.y + -transform.right.y * speed);
                transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
                _Player_Animator.SetBool("walk", true);
                _Player_Animator.SetBool("idle", false);
            }


            if (Input.GetKey(KeyCode.S))
                newVel = new Vector2(newVel.x + -transform.up.x * speed, newVel.y + -transform.up.y * speed);


            if (Input.GetKey(KeyCode.D))
            {
                newVel = new Vector2(newVel.x + transform.right.x * speed, newVel.y + transform.right.y * speed);
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
                _Player_Animator.SetBool("walk", true);
                _Player_Animator.SetBool("idle", false);
            }



            _rigidbody2D.velocity = newVel;
        }


        // When in air we need particles. and a bit different movement.
        private void InAirMovement()
        {
            var newVel = _rigidbody2D.velocity * (0.9f * Time.deltaTime);

            // Up
            if (Input.GetKey(KeyCode.W) && !Rotated)
            {
                _Player_Animator.SetBool("jump", false);
                newVel += new Vector2(transform.up.x * speed, transform.up.y * speed);
                if (!smoke_left_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_left_bottom, new KeyCode[] {KeyCode.D, KeyCode.W}));
                if (!smoke_right_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_right_bottom, new KeyCode[] {KeyCode.A, KeyCode.W}));
            }

            // Down
            else if (Input.GetKey(KeyCode.S))
            {
                newVel += new Vector2(-transform.up.x * speed, -transform.up.y * speed);
                if (!smoke_left_top.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_left_top, new KeyCode[] {KeyCode.S}));
                if (!smoke_right_top.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_right_top, new KeyCode[] {KeyCode.S}));
            }

            // Rotation.
            //Left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 1), 200 * Time.deltaTime);
                if (!smoke_right_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_right_bottom, new KeyCode[] {KeyCode.A, KeyCode.W}));
            }

            //Right
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, 1), -200 * Time.deltaTime);
                if (!smoke_left_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_left_bottom, new KeyCode[] {KeyCode.D, KeyCode.W}));
            }

            _rigidbody2D.velocity = newVel;
        }


        // Removes smoke after ... seconds if you are no longer holding your movement key
        private IEnumerator ActivateSmoke(ParticleSystem particleSystem, IReadOnlyList<KeyCode> codes)
        {
            if (!particleSystem.isPlaying) particleSystem.Play();

            yield return new WaitForSeconds(0.3f);

            if (!_pullToGround.getInAir())
            {
                particleSystem.Stop();
            }
            else
            {
                bool isPressed = false;
                for (var i = 0; i < codes.Count; i++)
                {
                    if (Input.GetKey(codes[i]))
                    {
                        isPressed = true;
                    }
                }

                if (isPressed)
                {
                    StartCoroutine(ActivateSmoke(particleSystem, codes));
                }
                else
                {
                    particleSystem.Stop();
                }
            }
        }
    }
}