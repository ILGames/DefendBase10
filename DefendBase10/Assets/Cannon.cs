using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cannon : MonoBehaviour
{
    public Transform spawner;

    void Update()
    {
        Fire();
    }

    public void Fire()
    {
        GameObject ctrlPanel = GameObject.Find("ControlPanel");
        ToggleButtonManager buttonValue = ctrlPanel.GetComponent<ToggleButtonManager>();
        //Debug.Log("Button ="+buttonValue.buttonValue);

        foreach (Transform child in spawner)
        {
            if (child.gameObject.name == "" + buttonValue.buttonValue)
            {
                Destroy(child.gameObject);
            }
        }
        /*
       	ShipValue valueScript = GetComponent<ShipValue>();
       	
        GameObject ship = GameObject.Find("" + valueScript.value);

        if (valueScript.value == buttonValue.buttonValue)
        {
            Destroy(ship);
        }
        */
    }
}
