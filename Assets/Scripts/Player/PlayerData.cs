using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerData
{
    private List<ItemData> inventory;
    private float Lucht = 100;

    public PlayerData()
    {
        inventory = new List<ItemData>();
    }


    public List<ItemData> getinventory()
    {
        return this.inventory;
    }

    public float lucht
    {
        get { return Lucht; }
        set
        {
            if (lucht >= 0)
            {
                Lucht = value;
            }
        }
    }
}