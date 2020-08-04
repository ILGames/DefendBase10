using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;



public float fireWait;
public float fireMostWait;
public float fireLeastWait;


public class Cannon : MonoBehaviour
{
    public Transform spawner;

    void Start()
    {
        StartCoroutine(waitFire());
    }

    void Update() 
    {
     fireWait = Random.Range(fireLeastWait, fireMostWait);    
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

        GameObject cannon = GamdObject.Find("Cannon");
    }

    IEnumerator waitFire()
    {
        yield return new WaitForSeconds(startWait);

        if (fireWait == true) 
        {
            Fire();
        }
    }
 }