using System.Collections;
using UnityEngine;

namespace meteorieten
{
    public class MeteoriteSpawner : MonoBehaviour
    {
        public GameObject[] asteroidObjects;
        public GameObject player;
        [SerializeField] private float heightThreshold = 5;
        

        [SerializeField] private float MaxSize = 1;
        [SerializeField] private float MinSize = 1;

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
            
            GameObject a = Instantiate(asteroidObjects[Random.Range(0, asteroidObjects.Length)], SpawningPos, Quaternion.identity) as GameObject;
            
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