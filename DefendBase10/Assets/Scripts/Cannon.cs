using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;


public class Cannon : MonoBehaviour
{
    public Transform spawner;
    public Transform pivot;
    public float startWait = 2f;
    public float fireWait = 5f;
    public CannonBar bar;


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

        bar.ResetBar();

        float lowY = 999999999;
        GameObject lowest = null;

        foreach (Transform child in spawner)
        {
            if (child.gameObject.name == "" + buttonValue.buttonValue)
            {
                if (child.position.y < lowY && child.position.y > transform.position.y)
                {
                    lowest = child.gameObject;
                    lowY = child.position.y;
                }
            }

            if (lowest != null)
            {
                KillShip(lowest);
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

    void KillShip(GameObject ship)
    {
        ship.GetComponent<ShipDeath>().Die();
    }
 }