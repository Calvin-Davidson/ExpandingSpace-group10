using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x -speedX*Time.deltaTime, transform.position.y -speedY*Time.deltaTime);

        if(transform.position.x < screenBounds.x - 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("hit");
            
            ParticleSystem g = Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(g, 2.0f);
    }
}
