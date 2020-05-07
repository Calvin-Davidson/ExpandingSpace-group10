using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{

    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}