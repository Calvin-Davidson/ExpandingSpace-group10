using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour
{
    public GameObject player;
    public GameObject asteroidObject;
    private Vector2 screenBounds;
    [SerializeField] private float heightThreshold = 5;
    private Vector2 tempPos;

    private void Update()
    {
        
    }
    void Start()
    {
        StartCoroutine(waiter());
    }
    private void spawnMeteor()
    {
        tempPos = new Vector2(player.transform.position.x, player.transform.position.y);
        GameObject a = Instantiate(asteroidObject) as GameObject;
        a.transform.position = new Vector2(tempPos.x, tempPos.y);
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {

        int wait_time = Random.Range(0, 1);
        yield return new WaitForSeconds(wait_time);
        tempPos = new Vector2(player.transform.position.x, player.transform.position.y);
        print("I waited for " + wait_time + "sec");
        spawnMeteor();
    }
}
