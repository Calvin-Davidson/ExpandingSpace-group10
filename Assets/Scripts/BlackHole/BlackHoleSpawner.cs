using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BlackHoleObject;
    
    List<Vector2> SpawnLocations = new List<Vector2>();
    private GameObject _Player;

    void Start()
    {
        _Player = GameObject.Find("Player");
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("BlackHoleSpawnLocation"))
        {
            SpawnLocations.Add(gameObject.transform.position);
        }
        StartCoroutine(TriggerClosest(0));
    }

    public IEnumerator TriggerClosest(float Time)
    {
        yield return new WaitForSeconds(Time);
        Vector2 closest = Vector2.zero;
        var playerPos = _Player.transform.position;
        foreach (Vector2 location in SpawnLocations)
        {
            if (Vector2.Distance(location, playerPos) < Vector2.Distance(closest, playerPos) || closest == Vector2.zero)
            {
                closest = location;
            }
        }

        if (Vector2.zero == closest)
        {
            StartCoroutine(TriggerClosest(UnityEngine.Random.Range(10, 25)));
        }
        else
        {
            GameObject blackHole = Instantiate(BlackHoleObject, closest, Quaternion.identity);

            StartCoroutine(TriggerClosest(UnityEngine.Random.Range(30, 60)));
        }
    }
}