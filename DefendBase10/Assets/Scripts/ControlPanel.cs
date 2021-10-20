using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ControlPanel : MonoBehaviour
{
    private Toggley[] buttons;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Toggley>();
        Array.Reverse(buttons);
        Debug.Log("Found buttons " + buttons.Length);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }
    public void Next(WaveManager.Wave wave)
    {
        int digits = wave.digits;
        index = digits;
        for (int i = 0; i < buttons.Length; i++)
        {
            Toggley button = buttons[i];
            if(i < digits)
            {
                if(!button.gameObject.activeSelf){
                    button.gameObject.SetActive(true);
                    Toggle toggle = button.gameObject.GetComponent<Toggle>();
                    toggle.interactable = true;
                }
            }else{
                if(button.gameObject.activeSelf){
                    button.gameObject.SetActive(false);
                    Toggle toggle = button.gameObject.GetComponent<Toggle>();
                    toggle.interactable = false;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
