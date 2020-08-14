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
    public float beamWait = 1f;
    public CannonBar bar;
    public GameObject Beam;

    void Start()
    {
        StartCoroutine(waitFire());
        Beam.SetActive(false);
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
        }
        if (lowest != null)
        {
            Vector3 shipPos = lowest.transform.position;
            Vector3 cannonPos = pivot.transform.position;
            shipPos.z = 0;
            cannonPos.z = 0;
            Vector3 cannon2ShipVector = shipPos - cannonPos;
            cannon2ShipVector.Normalize();
            Quaternion cannonRot = Quaternion.LookRotation(-Vector3.forward, cannon2ShipVector);
            pivot.transform.rotation = cannonRot;
            Beam.SetActive(true);
            StartCoroutine(waitBeam());
            
            KillShip(lowest);
           
        }
    }

    IEnumerator waitBeam() 
    {
        Beam.SetActive(true);

        yield return new WaitForSeconds(beamWait);

        Beam.SetActive(false);
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

    public void KillShip(GameObject ship)
    {
        ship.GetComponent<ShipDeath>().Die();
    }
 }

