using System.Collections.Generic;
using Items;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Player
{
    public class ItemsToShip : MonoBehaviour
    {
        private List<ItemData> PlayerInventory;
        private PlayerManager _playerManager;

        [SerializeField] private GameObject[] items;

        private void Start()
        {
            _playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
            if (GetComponent<PlayerManager>() == null)
            {
                Debug.Log("PlayerManager");
            }
        
            PlayerInventory = _playerManager.GetPlayerData().getinventory();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "SPACE_STATION" || other.gameObject.tag == "SPACE_STATION")
            {
                _playerManager.GetPlayerData().lucht = 100;
            
                foreach (ItemData itemData in PlayerInventory)
                {
                    GameObject g = GameObject.Find(itemData.getUIgameobjectName());
                    if (g != null)
                    {
                        g.GetComponent<Image>().enabled = (true);
                    }
                    else
                    {
                        Debug.LogError("Gameobject not found required name: " + itemData.getUIgameobjectName());
                    }
                }

                // cleared de PlayerInventory
                PlayerInventory.Clear();
            }
        }
    }
}