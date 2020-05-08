using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pickup;
    [SerializeField] private SpawnPoint[] SpawnLocations;
    private List<SpawnPoint> locations = new List<SpawnPoint>();
    private List<SpawnPoint> SelectedLocations = new List<SpawnPoint>();
    private int ItemCount = 3;
    private void Start()
    {

        if (ItemCount > SpawnLocations.Length)
        {
            Debug.LogError("Teveel items met te weinig spawn locations!");
            return;
        }

        System.Random r = new System.Random();
        Shuffle(r, SpawnLocations);

        for (int i = 0; i < SpawnLocations.Length; i++)
        {
            locations.Add(SpawnLocations[i]);
        }

        for (int i = 0; i < ItemCount; i++)
        {
            Debug.Log(i);
            int random = Random.Range(0, ItemCount - i);

            SelectedLocations.Add(locations[random]);
            locations.RemoveAt(random);
        }

        spawnItems();
    }

    private void spawnItems()
    {
        for (int i = 0; i < SelectedLocations.Count; i++)
        {
            if (SelectedLocations[i] == null || SelectedLocations[i].GetSpawnPosition() == null)
            {

            }
            else
            {
                Instantiate(pickup, SelectedLocations[i].GetSpawnPosition(), Quaternion.identity);
            }
        }
    }

    public void Shuffle<T>(System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
 
    }

}
