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

    int randEnemy;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            randEnemy = Random.Range(0, 10);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, 0);

            GameObject newShip = Instantiate(enemy, Vector3.zero, transform.rotation);
            newShip.transform.SetParent(transform);
            TextMesh shipText = newShip.transform.Find("Text");
            shipText.text = ""+Random.Range(0, 64);
            // Debug.Log("spawner at "+transform.position.z+" ship at "+newShip.transform.position.z);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}