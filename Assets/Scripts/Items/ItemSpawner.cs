using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private bool FromArray = true;

        [SerializeField] private SpawnPoint[] SpawnLocations;
        private List<SpawnPoint> locations = new List<SpawnPoint>();
        private List<SpawnPoint> SelectedLocations = new List<SpawnPoint>();
        [SerializeField] private GameObject[] ItemsToSpawn;

        private void Start()
        {
            if (FromArray == false)
            {
                foreach (var obj in GameObject.FindGameObjectsWithTag("Item_Spawn_location"))
                {
                    SpawnPoint point = obj.GetComponent<SpawnPoint>();
                    if (point != null) locations.Add(point);
                }
            }
            else
            {
                if (ItemsToSpawn.Length > SpawnLocations.Length)
                {
                    Debug.LogError("Teveel items met te weinig spawn locations!");
                    return;
                }

                for (int i = 0; i < SpawnLocations.Length; i++)
                {
                    locations.Add(SpawnLocations[i]);
                }
            }

            Shuffle(locations);

            for (int i = 0; i < ItemsToSpawn.Length; i++)
            {
                int random = Random.Range(0, ItemsToSpawn.Length - i);

                SelectedLocations.Add(locations[random]);
                locations.RemoveAt(random);
            }

            spawnItems();
        }

        private void spawnItems()
        {
            for (int i = 0; i < SelectedLocations.Count; i++)
            {
                if (SelectedLocations[i] != null && SelectedLocations[i].GetSpawnPosition() != null)
                {
                    Instantiate(ItemsToSpawn[i], SelectedLocations[i].GetSpawnPosition(), Quaternion.identity);
                }
            }
        }

        public void Shuffle<T>(IList<T> list)
        {
            System.Random rng = new System.Random();

            int n = list.Count;
            while (n > 1)
            {
                n--; 
                var k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public int getItemCount()
        {
            return this.ItemsToSpawn.Length;
        }
    }
}