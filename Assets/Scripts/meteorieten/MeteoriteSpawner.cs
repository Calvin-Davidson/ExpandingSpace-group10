using System.Collections;
using UnityEngine;

namespace meteorieten
{
    public class MeteoriteSpawner : MonoBehaviour
    {
        public GameObject[] asteroidObjects;
        public GameObject player;
        [SerializeField] private float heightThreshold = 5;
        private Vector2 tempPos;

        

        void Start()
        {
            
            StartCoroutine(waiter());
        }

        private void spawnMeteor()
        {
            tempPos = new Vector2(player.transform.position.x, player.transform.position.y);
            GameObject a = Instantiate(asteroidObjects[Random.Range(0, asteroidObjects.Length)]) as GameObject;
            a.transform.position = new Vector2(tempPos.x + 20, Random.Range(tempPos.y+1, tempPos.y+3));
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