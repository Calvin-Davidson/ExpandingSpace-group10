using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemsToShip : MonoBehaviour
{
    private List<ItemData> PlayerInventory;

    [SerializeField] private GameObject[] items;

    private void Start()
    {
        if (GetComponent<PlayerManager>() == null)
        {
            Debug.Log("PlayerManager");
        }

        PlayerInventory = GetComponent<PlayerManager>().GetPlayerData().getinventory();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "SPACE_STATION" || other.gameObject.tag == "SPACE_STATION")
        {
            GetComponent<PlayerManager>().GetPlayerData().lucht = 100;
            
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