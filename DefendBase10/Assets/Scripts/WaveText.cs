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


    void Update()
    {
        textDisplay.text = sentences[index];
    }
    public void ResetText()
    {
        index++;
    }
}