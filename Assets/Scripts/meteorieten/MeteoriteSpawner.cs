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

<<<<<<< HEAD
=======

        [SerializeField] private float MaxSize = 1;
        [SerializeField] private float MinSize = 1;
>>>>>>> ea9ebc3e6a2a43cfb6207d8d5d5009fc8fa22140
        

        void Start()
        {
            
            StartCoroutine(waiter());
        }

        private void spawnMeteor()
        {
            tempPos = new Vector2(player.transform.position.x, player.transform.position.y);
            GameObject a = Instantiate(asteroidObjects[Random.Range(0, asteroidObjects.Length)]) as GameObject;
<<<<<<< HEAD
            a.transform.position = new Vector2(tempPos.x + 20, Random.Range(tempPos.y+1, tempPos.y+3));
=======
            a.transform.position = new Vector2(tempPos.x + 50, Random.Range(tempPos.y+5, tempPos.y+8));
            float r = Random.Range(MinSize, MaxSize);
            a.transform.localScale = new Vector3(r, r, r);
>>>>>>> ea9ebc3e6a2a43cfb6207d8d5d5009fc8fa22140
            StartCoroutine(waiter());
        }

        IEnumerator waiter()
        {
            int wait_time = Random.Range(2, 5);
            yield return new WaitForSeconds(wait_time);
            spawnMeteor();
        }
    }
}