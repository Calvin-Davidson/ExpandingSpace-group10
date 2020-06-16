using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class ItemPickup : MonoBehaviour
    {
        private List<ItemData> playerInventory;
        [SerializeField] private AudioSource PickupSound;
        [SerializeField] private ParticleSystem _particleSystem;
        private void Start()
        {
            playerInventory = GetComponent<PlayerManager>().GetPlayerData().getinventory();
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "PickupItem")
            {
                playerInventory.Add(other.gameObject.GetComponent<ItemData>());
                
                PickupSound.Play();
                
                Destroy(other.gameObject);
                var particleSpawnSystem = other.gameObject.transform.position;
                ParticleSystem particleSystem = Instantiate(_particleSystem, particleSpawnSystem, Quaternion.identity);
                particleSystem.Play();
                
                Destroy(particleSystem, 1.5f);
            }
        }
    }
}