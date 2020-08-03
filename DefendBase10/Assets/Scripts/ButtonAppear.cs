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
}