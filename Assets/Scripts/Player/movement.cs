using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class movement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        [SerializeField] private ParticleSystem[] DoubleJumpSmokes;
        
        [SerializeField] private float speed = 8;
        [SerializeField] private float JumpHeight = 8;

        private GameObject _PlayerTexture;

        public bool inAir = true;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _PlayerTexture = GameObject.Find("PlayerTexture");
            foreach (var doubleJumpSmoke in DoubleJumpSmokes)
            {
                doubleJumpSmoke.Stop();
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.velocity = (new Vector2(-speed, _rigidbody2D.velocity.y));
                _PlayerTexture.transform.localScale = new Vector2(0.5521979f, _PlayerTexture.transform.localScale.y);
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, JumpHeight));
                if (inAir) Smoke(DoubleJumpSmokes);
            }

            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, -speed));

            }

            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.velocity = (new Vector2(speed, _rigidbody2D.velocity.y));
                _PlayerTexture.transform.localScale = new Vector2(-0.5521979f, _PlayerTexture.transform.localScale.y);
            }
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