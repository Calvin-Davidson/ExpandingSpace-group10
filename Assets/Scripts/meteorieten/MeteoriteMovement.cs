using UnityEngine;

namespace meteorieten
{
    public class MeteoriteMovement : MonoBehaviour
    {
        private Vector2 screenBounds;
        [SerializeField] private float speedX;
        [SerializeField] private float speedY;

        public ParticleSystem ExplosionParticle;

        private void Start()
        {
            speedX = Random.Range(5, 15);
            speedY = Random.Range(0.5f, 2f);
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            
            Destroy(this.gameObject, 30);
        }
        void Update()
        {
            transform.position = new Vector2(transform.position.x -speedX*Time.deltaTime, transform.position.y -speedY*Time.deltaTime);
        }
    
    }
}