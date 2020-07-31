using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonsOnScreen : MonoBehaviour
{
    public Toggley[] buttons;
    public int buttonsAnimated;



    void Update()
    {
	Toggley toggley;
        buttonsAnimated = 0;
	for(int index = 0; index <buttons.Length; index++)
	{
		toggley = buttons[index];
		Debug.Log("Toggley.gameObject" + toggley.gameObject);
		Toggle toggle = toggley.gameObject.GetComponent<Toggle>();
		if (toggle.interactable)
		{
			buttonsAnimated +=1;
		}

	}
    }
}
