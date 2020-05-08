using System.Collections;
using UnityEngine;

namespace meteorieten
{
    public class MeteoriteSpawner : MonoBehaviour
    {
        public GameObject[] asteroidObjects;
        private Vector2 screenBounds;
        [SerializeField] private float heightThreshold = 5;

        private Camera cam;

        void Start()
        {
            cam = Camera.main;
            StartCoroutine(waiter());
        }

        private void spawnMeteor()
        {
            screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            GameObject a = Instantiate(asteroidObjects[Random.Range(0, asteroidObjects.Length)]) as GameObject;
            a.transform.position = new Vector2(screenBounds.x * 2,
                Random.Range(-screenBounds.y + heightThreshold, screenBounds.y));
            StartCoroutine(waiter());
        }

        IEnumerator waiter()
        {
            int wait_time = Random.Range(2, 5);
            yield return new WaitForSeconds(wait_time);
            print("I waited for " + wait_time + "sec");
            spawnMeteor();
        }
    }
}