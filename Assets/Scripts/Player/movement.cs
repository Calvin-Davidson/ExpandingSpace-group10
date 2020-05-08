using System.Collections;
using UnityEngine;

namespace Player
{
    public class movement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        [SerializeField] private ParticleSystem[] DoubleJumpSmokes;

        [SerializeField] public int jumpCount = 0;
        [SerializeField] private float speed = 8;
        [SerializeField] private float JumpHeight = 8;

        private GameObject PlayerTexture;
    
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            PlayerTexture = GameObject.Find("PlayerTexture");
            foreach (var doubleJumpSmoke in DoubleJumpSmokes)
            {
                doubleJumpSmoke.Stop();
            }
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.velocity = (new Vector2(-speed, _rigidbody2D.velocity.y));
                PlayerTexture.transform.localScale = new Vector2(0.5521979f, PlayerTexture.transform.localScale.y);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (jumpCount < 2) 
                {
                    _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, JumpHeight));
                    jumpCount += 1;

                    if (jumpCount == 2)
                    {
                        foreach (var doubleJumpSmoke in DoubleJumpSmokes)
                        {
                            doubleJumpSmoke.Play();
                            StartCoroutine(removeSmoke());
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, -speed));
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.velocity = (new Vector2(speed, _rigidbody2D.velocity.y));
                PlayerTexture.transform.localScale = new Vector2(-0.5521979f, PlayerTexture.transform.localScale.y);
            }
        }

        public IEnumerator removeSmoke()
        {
            yield return new WaitForSeconds(0.2f);
            foreach (var doubleJumpSmoke in DoubleJumpSmokes)
            {
                doubleJumpSmoke.Stop();
            }
        }
    }
}