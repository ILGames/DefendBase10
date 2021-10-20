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


        Camera camera = Camera.main;

        float distanceFromCamera = camera.nearClipPlane + camera.transform.position.z; // Change this value if you want
        Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, distanceFromCamera));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, distanceFromCamera));

        transform.position = new Vector3(transform.position.x, topLeft.y, transform.position.z);
        return; 

        Debug.Log("aaa "+Camera.main);
        Debug.Log("aaa2 "+Screen.width);
        Vector3 top_right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector3 bottom_left = Camera.main.ScreenToWorldPoint(Vector3.zero);

        // update spawner position
        Debug.Log(transform.position);
        transform.position = new Vector3(transform.position.x, top_right.y, transform.position.z);
        Debug.Log(transform.position);
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
        // any remaining ships need to animate off screen and go away
        ShipRetreat[] reatreats = gameObject.GetComponentsInChildren<ShipRetreat>();
        for (int i = 0; i < reatreats.Length; i++)
        {
            reatreats[i].Retreat();
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
        Vector3 spawnPosition = new Vector3( Random.Range(-475, 475), 0, 0);

        GameObject newShip = Instantiate(enemy, transform);
        newShip.transform.localPosition = spawnPosition;
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