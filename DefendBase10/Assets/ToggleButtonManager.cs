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
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Toggley btn in buttons)
		{
		buttonValue = btn.value * (int)Math.Pow(2, btn.digitNum);
		}
    }
}
