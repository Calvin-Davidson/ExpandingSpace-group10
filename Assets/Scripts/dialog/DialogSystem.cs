using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogSystem : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private PlayerData _playerData;

    private int luchtDialog = 0;

    private void Start()
    {
        _playerData = GameObject.Find("Player").GetComponent<PlayerManager>().GetPlayerData();
        txt = GetComponent<TextMeshProUGUI>();

        StartCoroutine(dialogtimer(1, "Je schip is gecrashed, vind snel de onderdelen!."));
        StartCoroutine(dialogtimer(3, "let wel op je lucht, bij je schip kan je lucht bijvullen"));
        StartCoroutine(dialogtimer(3, ""));
    }

    public void Dialog(float time, string txt)
    {
        StartCoroutine(dialogtimer(time, txt));
    }

    private void Update()
    {
        if (_playerData.lucht == 16.4)
        {
            if (luchtDialog < 2)
            {
                List<string> LuchtOpArray = new List<string>();
                LuchtOpArray.Add("let op je lucht is bijna op!");
                LuchtOpArray.Add("Denk aan je lucht");
                LuchtOpArray.Add("Links boven kan je zien hoeveel lucht je hebt, let erop!");
                LuchtOpArray.Add("Zonder lucht hou je het niet vol let erop!");
                StartCoroutine(dialogtimer(1, LuchtOpArray[Random.Range(0, LuchtOpArray.Count)]));
            }
        }
    }

    private IEnumerator dialogtimer(float waitFor, string text)
    {
        yield return new WaitForSeconds(waitFor);
        txt.text = text;

        StartCoroutine(removeAfter(2.5f, text));
    }

    private IEnumerator removeAfter(float waitTime, string txt)
    {
        yield return new WaitForSeconds(waitTime);
        if (this.txt.text == txt)
        {
            this.txt.text = "";
        }
    }


    public void setDialog()
    {
    }
}