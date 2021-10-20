using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipValue : MonoBehaviour
{
    public int value = 0;
    ButtonsOnScreen buttonsShowing;
    ControlPanel controlPanel;
    MaterialPropertyBlock block;
    Color[] colors = new Color[10];

    Renderer _rendererC;
    Renderer _rendererF;
    void Awake()
    {
    GameObject form = gameObject.transform.Find("form").gameObject;
       GameObject cockpit = form.transform.Find("cockpit").gameObject;
       GameObject fuselage = form.transform.Find("fuselage").gameObject;
       _rendererC = cockpit.GetComponent<Renderer>();
       _rendererF = fuselage.GetComponent<Renderer>();
       block = new MaterialPropertyBlock();

        colors[0] = new Color(161.0f/255.0f, 253.0f/255.0f, 255.0f/255.0f);
        colors[1] = new Color(51.0f/255.0f, 158.0f/255.0f, 239.0f/255.0f);
        colors[2] = new Color(36.0f/255.0f, 49.0f/255.0f, 201.0f/255.0f);
        colors[3] = new Color(71.0f/255.0f, 22.0f/255.0f, 191.0f/255.0f);
        colors[4] = new Color(151.0f/255.0f, 22.0f/255.0f, 183.0f/255.0f);
        colors[5] = new Color(239.0f/255.0f, 34.0f/255.0f, 201.0f/255.0f);
        colors[6] = new Color(211.0f/255.0f, 17.0f/255.0f, 17.0f/255.0f);
        colors[7] = new Color(234.0f/255.0f, 109.0f/255.0f, 17.0f/255.0f);
        colors[8] = new Color(244.0f/255.0f, 199.0f/255.0f, 11.0f/255.0f);
        colors[9] = new Color(186.0f/255.0f, 247.0f/255.0f, 17.0f/255.0f);
    }
    void Start()
    {

    }

    public void RandomizeValue(int max = -1)
    {
        buttonsShowing = GameObject.Find("ControlPanel").GetComponent<ButtonsOnScreen>();
        controlPanel = GameObject.Find("ControlPanel").GetComponent<ControlPanel>();
       
        if (max < 0)
        {
            //max = (int)Mathf.Pow(2,buttonsShowing.buttonsAnimated);
            max = (int)Mathf.Pow(2, controlPanel.index);
            // Debug.Log("Max = " + max);
        }
        SetValue(Random.Range(0, max));
    }

    public void SetValue(int newValue)
    {
        value = newValue;
        Transform shipText = transform.Find("Text");
        TextMesh meshComponent = shipText.gameObject.GetComponent<TextMesh>();
        meshComponent.text = "" + value;

        int digitOne = Mathf.FloorToInt(value / 1) % 10;
        int digitTwo = Mathf.FloorToInt(value / 10) % 10;

        _rendererC.GetPropertyBlock(block);
        block.SetColor("_Color", colors[digitOne]); //Random.Range(0, colors.Length)
        _rendererC.SetPropertyBlock(block);

        _rendererF.GetPropertyBlock(block);
        block.SetColor("_Color", colors[digitTwo]); //Random.Range(0, colors.Length)
        _rendererF.SetPropertyBlock(block);
    }
    
}
