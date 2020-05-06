using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerData
{
    public PlayerData()
    {
    }
}


public class temp : MonoBehaviour
{
    [SerializeField] private String[] SpawnLocations;
    private List<SpawnPoint> SelectedLocations = new List<SpawnPoint>();
    private int ItemCount = 3;

    private void Start()
    {
        if (ItemCount > SpawnLocations.Length)
        {
            Debug.LogError("Teveel items met te weinig spawn locations!");
            return;
        }

        for (int i = 0; i < ItemCount; i++)
        {
            int random = Random.Range(0, ItemCount);
            SelectedLocations.Add(SpawnLocations[random]);
            SpawnLocations[random] = null;

            spawnItmes();
        }

        private void spawnItmes()
        {
            for (int i = 0; i < SelectedLocations.Count; i++)
            {
                // spawn de objects.
            }
        }
    }