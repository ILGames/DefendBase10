using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public WaveManager wavemanager;
    public string[] sentences;
    private int index;

/*
    void Update()
    {
        if (sentences.Length>index)
        {
            textDisplay.text = sentences[index];
        }
    }*/
    public void Init(int start)
    {
        index = start;
    }
    public void ResetText(int total)
    {
        //index++;
        textDisplay.text = "Wave: " + System.Convert.ToString(total, 2);        
    }
}