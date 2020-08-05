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

    int maxNum = 2;

    ButtonsOnScreen buttonsShowing;

    void Start()
    {
        StartCoroutine(waitSpawner());

        GameObject controlPanel = GameObject.Find("ControlPanel");
        buttonsShowing = controlPanel.GetComponent<ButtonsOnScreen>();
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
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