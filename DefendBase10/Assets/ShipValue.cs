using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipValue : MonoBehaviour
{
    public int value = 0;

    public void RandomizeValue(int max)
    {
        SetValue(Random.Range(0, max));
    }

    public void SetValue(int newValue)
    {
        value = newValue;
        Transform shipText = transform.Find("Text");
        TextMesh meshComponent = shipText.gameObject.GetComponent<TextMesh>();
        meshComponent.text = "" + value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
