using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cannon : MonoBehaviour
{
    public void destroy() 
    {

        ShipValue valueScript = GetComponent<ShipValue>();
        ToggleButtonManager buttonValue = GetComponent<ToggleButtonManager>();

        if (valueScript.value == buttonValue.buttonValue)
        {
            GameObject destroyShip = GameObject.Find("" + valueScript.value);
            Destroy(destroyShip);
        }
    }
}
