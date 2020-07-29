using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cannon : MonoBehaviour
{

    public void destroy() 
    {
       	ShipValue valueScript = GetComponent<ShipValue>();
       	ToggleButtonManager buttonValue = GetComponent<ToggleButtonManager>();
        GameObject ship = GameObject.Find("" + valueScript.value);

        if (valueScript.value == buttonValue.buttonValue)
        {
            Destroy(ship);
        }
    }
}
