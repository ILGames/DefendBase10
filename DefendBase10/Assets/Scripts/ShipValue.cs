using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipValue : MonoBehaviour
{
    public int value = 0;
    ButtonsOnScreen buttonsShowing;

    void Awake()
    {
        
    }

    public void RandomizeValue(int max = -1)
    {
        buttonsShowing = GameObject.Find("ControlPanel").GetComponent<ButtonsOnScreen>();
        Debug.Log("Buttons = "+ buttonsShowing.buttonsAnimated);

        if (max < 0)
        {
            max = (int)Mathf.Pow(2,buttonsShowing.buttonsAnimated) - 1;
            Debug.Log("Max = " + max);
        }
        SetValue(Random.Range(0, max));
    }

    public void SetValue(int newValue)
    {
        value = newValue;
        Transform shipText = transform.Find("Text");
        TextMesh meshComponent = shipText.gameObject.GetComponent<TextMesh>();
        meshComponent.text = "" + value;
    }
    
}
