using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace meteorieten
{
    public class MeteoriteMovement : MonoBehaviour
    {
        [SerializeField] private float speedX;
        [SerializeField] private float speedY;

        public ParticleSystem ExplosionParticle;

        private void Start()
        {
            speedX = Random.Range(55, 85);
            speedY = Random.Range(5.5f, 8f);

            Destroy(this.gameObject, 30);
        }
        

        void Update()
        {
            transform.position = new Vector2(transform.position.x - speedX * Time.deltaTime,
                transform.position.y - speedY * Time.deltaTime);
        }
    }
}