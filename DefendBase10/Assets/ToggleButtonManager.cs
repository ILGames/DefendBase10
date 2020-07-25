using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ToggleButtonManager : MonoBehaviour
{
    public Toggley[] buttons;
    public int buttonValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Num Buttons = " + buttons.Length);
    }

    // Update is called once per frame
    void Update()
    {
	int tempValue = 0;
        foreach(Toggley btn in buttons)
	{
		int digitValue = (int)Math.Pow(2, btn.digitNum);
		int newValue = btn.value * digitValue;
		Debug.Log("Value of digit " + btn.digitNum + " is " + btn.value);
		tempValue = tempValue + newValue;
	}
	buttonValue = tempValue;
    }
}
