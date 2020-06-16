using System;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int numHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private PlayerData _playerData;

    private void Start()
    {
        _playerData = GameObject.Find("Player").GetComponent<PlayerManager>().GetPlayerData();
    }

    private void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < _playerData.getHealth())
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
