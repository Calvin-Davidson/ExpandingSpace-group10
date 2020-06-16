using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Trailer : MonoBehaviour
{
    public VideoPlayer VideoPlayer;

    public GameObject mainCanvas;
    // Update is called once per frame
    void Update()
    {
        if (VideoPlayer.isPlaying == false)
        {
            mainCanvas.SetActive(true);
            Destroy(this);
        }
    }
}
