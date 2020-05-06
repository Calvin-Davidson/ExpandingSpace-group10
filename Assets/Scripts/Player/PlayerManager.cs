using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerData _playerData;

    private void Start()
    {
        _playerData = new PlayerData();
    }


    public PlayerData GetPlayerData()
    {
        return this._playerData;
    }
}
