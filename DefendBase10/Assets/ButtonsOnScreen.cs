using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonsOnScreen : MonoBehaviour
{
    public Toggley[] buttons;
    [System.Serializable]
    public class ButtonsOn
    {
    	public int ButtonsAnimated;
    }
    public ButtonsOn buttonsOn;
    GameObject Button_2;
    GameObject Button_3;
    GameObject Button_4;
    GameObject Button_5;
    GameObject Button_6;
    GameObject Button_1;
    void Start()
    {
        Button_2 = GameObject.Find("Button_2");
        Button_3 = GameObject.Find("Button_3");
        Button_4 = GameObject.Find("Button_4");
        Button_5 = GameObject.Find("Button_5");
        Button_6 = GameObject.Find("Button_6");
    }

    void Update()
    {
	int buttons = 1;
        
	/*
	foreach()
	{
		if (toggley_2.interactable = true)
		{
			buttons +=1;
		}
		if (toggley_3.interactable = true)
		{
			buttons +=1;
		}
		if (toggley_4.interactable = true)
		{
			buttons +=1;
		}
		if (toggley_5.interactable = true)
		{
			buttons +=1;
		}
		if (toggley_6.interactable = true)
		{
			buttons +=1;
		}

	}
	ButtonsAnimated = buttons;
	*/

    }
}
