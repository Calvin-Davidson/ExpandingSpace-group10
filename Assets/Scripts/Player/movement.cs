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
        [SerializeField] private ParticleSystem[] DoubleJumpSmokes;

        [SerializeField] private float speed = 8;
        [SerializeField] private float JumpHeight = 8;
        [SerializeField] private float RotateSpeed = 10;

        private GameObject _PlayerObj;
        public bool inAir = true;
        private PlanetGravity _planetGravity;
        private Rigidbody2D _rigidbody2D;

        public bool jumpedFromPlanet = false;

        private void Start()
        {
            _planetGravity = GetComponent<PlanetGravity>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _PlayerObj = GameObject.Find("Player");
            foreach (var doubleJumpSmoke in DoubleJumpSmokes)
            {
                doubleJumpSmoke.Stop();
            }
        }

        private void Update()
        {
            Vector3 pos = transform.position;
            pos.z = 0;
            transform.position = pos;

            bool WalkAround = false;
            GameObject CurrentPlanet = null;
            foreach (var planet in _planetGravity.getPlanets())
            {
                if (planet.Value.hasPlayerOnIt())
                {
                    CurrentPlanet = planet.Key;
                    WalkAround = true;
                    break;
                }
            }

            if (!(WalkAround)) FlyInSpace();
            if (WalkAround) WalkAroundPlanet(CurrentPlanet);
        }

        public void WalkAroundPlanet(GameObject planet)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                _rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, JumpHeight * 2));
                jumpedFromPlanet = true;
                StartCoroutine(jumpTimer());
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (transform.rotation.z > -178 && transform.rotation.z < -180 ||
                    transform.rotation.z < 180 && transform.rotation.z > 0)
                {
                    Quaternion rotation = transform.rotation;
                    rotation.z += -RotateSpeed * Time.deltaTime;
                    Vector3 rot = new Vector3(rotation.x, rotation.y, rotation.z);
                    transform.RotateAround(planet.transform.position, rot, 0.3f);
                }
                else
                {
                    Quaternion rotation = transform.rotation;
                    rotation.z += RotateSpeed * Time.deltaTime;
                    Vector3 rot = new Vector3(rotation.x, rotation.y, rotation.z);
                    transform.RotateAround(planet.transform.position, rot, -0.3f);
                }

                _PlayerObj.transform.localScale = new Vector2(-Mathf.Abs(_PlayerObj.transform.localScale.x),
                    _PlayerObj.transform.localScale.y);
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (transform.rotation.z > -178 && transform.rotation.z < -180 ||
                    transform.rotation.z < 180 && transform.rotation.z > 0)
                {
                    Vector3 rot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                    transform.RotateAround(planet.transform.position, rot, -0.3f);
                }
                else
                {
                    Vector3 rot = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
                    transform.RotateAround(planet.transform.position, rot, 0.3f);
                }

                _PlayerObj.transform.localScale = new Vector2(Mathf.Abs(_PlayerObj.transform.localScale.x),
                    _PlayerObj.transform.localScale.y);
            }
        }

        public void FlyInSpace()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.velocity = -transform.right * speed;
                
                _PlayerObj.transform.localScale = new Vector2(-Mathf.Abs(_PlayerObj.transform.localScale.x),
                    _PlayerObj.transform.localScale.y);
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = transform.up * speed;
                //_rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, JumpHeight));
                if (inAir) Smoke(DoubleJumpSmokes);
            }

            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody2D.velocity = -transform.up * speed;
                //_rigidbody2D.velocity = (new Vector2(_rigidbody2D.velocity.x, -speed));
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.velocity = transform.right * speed;
//                _rigidbody2D.velocity = (new Vector2(speed, _rigidbody2D.velocity.y));
                _PlayerObj.transform.localScale = new Vector2(Mathf.Abs(_PlayerObj.transform.localScale.x),
                    _PlayerObj.transform.localScale.y);
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

        public IEnumerator jumpTimer()
        {
            yield return new WaitForSeconds(0.3f);
            jumpedFromPlanet = false;
        }
    }
}