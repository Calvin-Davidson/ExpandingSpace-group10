using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

namespace Player
{
    public class ItemsToShip : MonoBehaviour
    {
        private List<ItemData> PlayerInventory;
        private PlayerManager _playerManager;

        private int requiredItems = 0;

        private int foundItems = 0;

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
                        foundItems += 1;
                    }
                    else
                    {
                        Debug.LogWarning("Gameobject not found required name: " + itemData.getUIgameobjectName());
                    }
                }

                // cleared de PlayerInventory
                PlayerInventory.Clear();
            }

            if (foundItems >= 4)
            {
                // Als je wint
                SceneManager.LoadScene(3);
            }
        }
    }
}