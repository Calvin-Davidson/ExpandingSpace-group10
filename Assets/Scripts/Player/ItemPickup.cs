using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class ItemPickup : MonoBehaviour
    {
        private List<ItemData> playerInventory;

        private void Start()
        {
            if (GetComponent<PlayerManager>() == null)
            {
                Debug.Log("PlayerManager");
            }

            if (GetComponent<PlayerManager>().GetPlayerData() == null)
            {
                Debug.Log("PlayerData");
            }
            playerInventory = GetComponent<PlayerManager>().GetPlayerData().getinventory();
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "PickupItem")
            {
                playerInventory.Add(other.gameObject.GetComponent<ItemData>());
                Destroy(other.gameObject);
            }
        }
    }
}