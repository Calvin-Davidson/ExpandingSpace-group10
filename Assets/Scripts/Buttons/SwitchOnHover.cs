using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchOnHover : MonoBehaviour
{
    [SerializeField] private Sprite replaceWith;
    private Sprite startSprite;

    private void Start()
    {
        this.startSprite = GetComponent<Image>().sprite;
    }
    public void MouseEnter()
    {
        Debug.Log("Chani");
        this.GetComponent<Image>().sprite = replaceWith;
    }

    public void MouseExit()
    {
        this.GetComponent<Image>().sprite = startSprite;
    }
}
