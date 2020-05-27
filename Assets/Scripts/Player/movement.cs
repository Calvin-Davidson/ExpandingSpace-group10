using System;
using System.Collections;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class movement : MonoBehaviour
    {
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
        }

        // When on ground we walk around objects.
        private void onGroundMovement()
        {
            var newVel = _rigidbody2D.velocity * Time.deltaTime;

            // movement up.
            if (Input.GetKey(KeyCode.W) && Rotated == false)
                newVel = new Vector2(newVel.x + transform.up.x * speed * 1.3f, newVel.y + transform.up.y * speed * 1.3f);


            if (Input.GetKey(KeyCode.A))
            {
                newVel = new Vector2(newVel.x + -transform.right.x * speed, newVel.y + -transform.right.y * speed);
                transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
            }


            if (Input.GetKey(KeyCode.S))
                newVel = new Vector2(newVel.x + -transform.up.x * speed, newVel.y + -transform.up.y * speed);


            if (Input.GetKey(KeyCode.D))
            {
                newVel = new Vector2(newVel.x + transform.right.x * speed, newVel.y + transform.right.y * speed);
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y,
                    transform.localScale.z);
            }

            _rigidbody2D.velocity = newVel;
        }

        // When in air we need particles. and a bit different movement.
        private void InAirMovement()
        {
            var newVel = _rigidbody2D.velocity * Time.deltaTime;

            if (Input.GetKey(KeyCode.W) && Rotated == false)
            {
                newVel = new Vector2(newVel.x + transform.up.x * speed, newVel.y + transform.up.y * speed);
                if (!smoke_left_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_left_bottom, new KeyCode[] {KeyCode.D, KeyCode.W}));
                if (!smoke_right_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_right_bottom, new KeyCode[] {KeyCode.A, KeyCode.W}));
            }

            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(new Vector3(0, 0, 1), 200 * Time.deltaTime);
                if (!smoke_right_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_right_bottom, new KeyCode[] {KeyCode.A, KeyCode.W}));
            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, 0, 1), -200 * Time.deltaTime);
                if (!smoke_left_bottom.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_left_bottom, new KeyCode[] {KeyCode.D, KeyCode.W}));
            }
            else if (Input.GetKey(KeyCode.S))
            {
                newVel = new Vector2(newVel.x + -transform.up.x * speed, newVel.y + -transform.up.y * speed);
                if (!smoke_left_top.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_left_top, new KeyCode[] {KeyCode.S}));
                if (!smoke_right_top.isPlaying)
                    StartCoroutine(ActivateSmoke(smoke_right_top, new KeyCode[] {KeyCode.S}));
            }

            _rigidbody2D.velocity = newVel;
        }


        // Removes smoke after ... seconds if you are no longer holding your movement key
        private IEnumerator ActivateSmoke(ParticleSystem particleSystem, KeyCode[] codes)
        {
            if (!particleSystem.isPlaying) particleSystem.Play();
            
            yield return new WaitForSeconds(0.3f);

            if (!_pullToGround.getInAir())
            {
                particleSystem.Stop();
            }
            else
            {
                bool IsPressed = false;
                for (var i = 0; i < codes.Length; i++)
                {
                    if (Input.GetKey(codes[i]))
                    {
                        IsPressed = true;
                    }
                }

                if (IsPressed)
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