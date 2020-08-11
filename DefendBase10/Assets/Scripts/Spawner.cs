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
    public WaveManager waveManager;

    bool on = false;
    
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
        waveManager.waveCountdown -= Time.deltaTime;

    }

    void SpawnShip()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(2456, spawnValues.x), 2650, 17853);

        GameObject newShip = Instantiate(enemy, spawnPosition, transform.rotation);
        newShip.transform.SetParent(transform);
        ShipValue valueScript = newShip.GetComponent<ShipValue>();
        valueScript.RandomizeValue();

        newShip.name = "" + valueScript.value;
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (on)
        {

            SpawnShip();

            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}