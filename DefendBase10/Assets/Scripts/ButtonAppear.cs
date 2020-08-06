using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonAppear : MonoBehaviour{

	public Toggle toggle1, toggle2, toggle3, toggle4, toggle5, toggle6;
	GameObject Button_2;
	GameObject Button_3;
	GameObject Button_4;
	GameObject Button_5;
	GameObject Button_6;
	public string[] sentences;
	private int index;
	public WaveManager wavemanager;

	void Start() 
	{
        Button_2 = GameObject.Find("Button_2");
	toggle2.interactable = false;
        Button_3 = GameObject.Find("Button_3");
	toggle3.interactable = false;
        Button_4 = GameObject.Find("Button_4");
	toggle4.interactable = false;
        Button_5 = GameObject.Find("Button_5");
	toggle5.interactable = false;
        Button_6 = GameObject.Find("Button_6");
	toggle6.interactable = false;
	}
    void Update()
    {
		if(sentences[index] == "Wave 1")
        {
			toggle2.interactable = true;
        }
		if (sentences[index] == "Wave 11")
		{
			toggle3.interactable = true;
		}
		if (sentences[index] == "Wave 110")
		{
			toggle4.interactable = true;
		}
		if (sentences[index] == "Wave 1010")
		{
			toggle5.interactable = true;
		}
		if (sentences[index] == "Wave 10000")
		{
			toggle6.interactable = true;
		}
	}
	public void ResetDigits()
	{
		index++;
	}
}