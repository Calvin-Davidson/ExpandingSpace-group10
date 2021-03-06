﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Items;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

namespace Player
{
    public class ItemsToShip : MonoBehaviour
    {
        private List<ItemData> PlayerInventory;
        private PlayerManager _playerManager;
        private int requiredItems = 0;
        private int foundItems = 0;
        private bool hasCollision = false;

        [SerializeField] private GameObject[] items;
        [SerializeField] private Sprite[] sprites;

        private void Start()
        {
            _playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();

            PlayerInventory = _playerManager.GetPlayerData().getinventory();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "SPACE_STATION" || other.gameObject.tag == "SPACE_STATION")
            {
                hasCollision = true;
                StartCoroutine(AirFiller());

                foreach (ItemData itemData in PlayerInventory)
                {
                    GameObject g = GameObject.Find(itemData.getUIgameobjectName());
                    if (g != null)
                    {
                        g.GetComponent<Image>().sprite = itemData.getFoundSprite();
                        foundItems += 1;
                    }
                    else
                    {
                        Debug.LogWarning("Gameobject not found required name: " + itemData.getUIgameobjectName());
                    }
                }


                PlayerInventory.Clear();
            }

            if (foundItems >= 4)
            {
                // Als je wint
                SceneManager.LoadScene(3);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.name == "SPACE_STATION" || other.gameObject.tag == "SPACE_STATION")
            {
                hasCollision = false;
            }
        }

        private IEnumerator AirFiller()
        {
            yield return new WaitForSeconds(0.1f);

            _playerManager.GetPlayerData().lucht += 1;

            if (_playerManager.GetPlayerData().lucht > 100) _playerManager.GetPlayerData().lucht = 100;
            
            if (hasCollision && _playerManager.GetPlayerData().lucht < 100) StartCoroutine(AirFiller());
        }
    }
}