using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitchButton : MonoBehaviour
{
    [SerializeField] private GameObject fromCanvas;

    [SerializeField] private GameObject toCanvas;


    public void OnClick()
    {
        fromCanvas.SetActive(false);
        toCanvas.SetActive(true);
    }
}
