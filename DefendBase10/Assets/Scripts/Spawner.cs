using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;

    bool on = false;

    int maxNum = 2;
    IEnumerator coroutine;

    ButtonsOnScreen buttonsShowing;

    void Start()
    {
        GameObject controlPanel = GameObject.Find("ControlPanel");
        buttonsShowing = controlPanel.GetComponent<ButtonsOnScreen>();
    }

    public void StopSpawning()
    {
        Debug.Log("turning off spawner");
        on = false;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public void StartSpawning()
    {
        Debug.Log("turning on spawner");
        on = true;
        coroutine = waitSpawner();
        StartCoroutine(coroutine);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (on)
        {
            maxNum = 2^(buttonsShowing.buttonsAnimated-1);

            Vector3 spawnPosition = new Vector3(Random.Range(2456, spawnValues.x), 2650, 17853);

            GameObject newShip = Instantiate(enemy, spawnPosition, transform.rotation);
            newShip.transform.SetParent(transform);
            ShipValue valueScript = newShip.GetComponent<ShipValue>();
            valueScript.RandomizeValue(maxNum);
            
            newShip.name = "" + valueScript.value;
            //Debug.Log("new ship # = "+ valueScript.value);

            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}