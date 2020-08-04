using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    public Transform spawner;
    public float startWait = 2f;
    public float fireWait = 1f;

    void Start()
    {
        StartCoroutine(waitFire());
    }

    void Update() 
    {   
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
    }

    IEnumerator waitFire()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            Fire();

            yield return new WaitForSeconds(fireWait);
        }
    }
 }