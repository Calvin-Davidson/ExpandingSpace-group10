using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace meteorieten
{
    public class MeteoriteMovement : MonoBehaviour
    {
        [SerializeField] private float speedX;
        [SerializeField] private float speedY;

        private Rigidbody2D _rigidbody2D;

        public ParticleSystem ExplosionParticle;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            speedX = Random.Range(55, 85);
            speedY = Random.Range(5.5f, 8f);

            _rigidbody2D.AddForce(new Vector2(-speedX * 50, -speedY * 50));
            Destroy(gameObject, 30);
        }
    }
}