using UnityEngine;

namespace Items
{
    public class SpawnPoint : MonoBehaviour
    {
        public Vector2 GetSpawnPosition()
        {
            return transform.position;
        }
    }
}