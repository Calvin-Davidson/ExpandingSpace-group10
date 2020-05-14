using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class movement : MonoBehaviour
    {
        [SerializeField] private float speed = 8;
        [SerializeField] private float JumpHeight = 8;
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;

            bool WalkAround = false;
            GameObject CurrentPlanet = null;

            movement_02();
            // FlyInSpace();
        }

        public void movement_02()
        {
            Vector2 newVel = _rigidbody2D.velocity * Time.deltaTime;

            if (Input.GetKey(KeyCode.W))
                newVel = new Vector2(newVel.x + transform.up.x * speed, newVel.y + transform.up.y * speed);
            if (Input.GetKey(KeyCode.A))
                newVel = new Vector2(newVel.x + -transform.right.x * speed, newVel.y + -transform.right.y * speed);
            if (Input.GetKey(KeyCode.S))
                newVel = new Vector2(newVel.x + -transform.up.x * speed, newVel.y + -transform.up.y * speed);
            if (Input.GetKey(KeyCode.D))
                newVel = new Vector2(newVel.x + transform.right.x * speed, newVel.y + transform.right.y * speed);
            _rigidbody2D.velocity = newVel;

            Debug.Log("moved");
        }

        public void FlyInSpace()
        {
            var velX = _rigidbody2D.velocity.x;
            var VelY = _rigidbody2D.velocity.y;
            
            if (Input.GetKey(KeyCode.W))
                _rigidbody2D.velocity = new Vector2(velX * Time.deltaTime, VelY + speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
                _rigidbody2D.velocity = new Vector2(velX - speed * Time.deltaTime, VelY * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                _rigidbody2D.velocity = new Vector2(velX * Time.deltaTime, VelY - speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                _rigidbody2D.velocity = new Vector2(velX + speed * Time.deltaTime, VelY * Time.deltaTime);
            ;
        }


        public void Smoke(ParticleSystem[] systems)
        {
            foreach (var doubleJumpSmoke in systems)
            {
                doubleJumpSmoke.Play();
            }

            StartCoroutine(removeSmoke(systems));
        }

        public IEnumerator removeSmoke(ParticleSystem[] systems)
        {
            yield return new WaitForSeconds(0.2f);
            foreach (var doubleJumpSmoke in systems)
            {
                doubleJumpSmoke.Stop();
            }
        }
    }
}