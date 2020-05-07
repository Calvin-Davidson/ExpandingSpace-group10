using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    [SerializeField] private string UIiconGameObjectName;

    public string getUIgameobjectName()
    {
        return this.UIiconGameObjectName;
    }
}
