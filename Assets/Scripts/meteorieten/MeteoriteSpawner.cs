using System.Collections;
using UnityEngine;

namespace meteorieten
{
    public class MeteoriteSpawner : MonoBehaviour
    {
        public GameObject[] asteroidObjects;
        public GameObject[] stalkingAsteriod;
        public GameObject player;
        [SerializeField] private float heightThreshold = 5;
        

        [SerializeField] private float MaxSize = 1;
        [SerializeField] private float MinSize = 1;

        [SerializeField] private int StalkingSpawnChange = 5;

        void Start()
        {
        StartCoroutine(waiter());
        }

        private void spawnMeteor()
        {
            Vector3 SpawningPos = player.transform.position;
            SpawningPos.x += 125;
            SpawningPos.y += Random.Range(-40, 40);
            SpawningPos.z = 0;

            GameObject spawning;
            if (Random.Range(0, 100) < StalkingSpawnChange)
            {
                spawning = stalkingAsteriod[Random.Range(0, stalkingAsteriod.Length)];
            }
            else
            {
                spawning = asteroidObjects[Random.Range(0, asteroidObjects.Length)];
            }

            if (!spawning) return;
            
            GameObject a = Instantiate(spawning, SpawningPos, Quaternion.identity);
            
            float r = Random.Range(MinSize, MaxSize);
            a.transform.localScale = new Vector3(r, r, r);
            
            StartCoroutine(waiter());
        }

        IEnumerator waiter()
        {
            int wait_time = Random.Range(0, 2);
            yield return new WaitForSeconds(wait_time);
            spawnMeteor();
        }
    }
}