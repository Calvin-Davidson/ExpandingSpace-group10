using System;
using UnityEngine;

namespace meteorieten
{
    public class MeteorietenCollision : MonoBehaviour
    {
        private Boolean enteredCollision = false;
        [SerializeField] private ParticleSystem ExplosionParticle;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (enteredCollision) return;
            enteredCollision = true;
            if (ExplosionParticle != null)
            {
                ParticleSystem g = Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
                Destroy(g, 2.0f);
            }
            Destroy(gameObject);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (enteredCollision) return;
            enteredCollision = true;
            if (ExplosionParticle != null)
            {
                ParticleSystem g = Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
                Destroy(g, 2.0f);
            }
            Destroy(gameObject);
        }

    }
}