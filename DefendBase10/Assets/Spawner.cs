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
            Vector3 spawnPosition = new Vector3(Random.Range(2456, spawnValues.x), 2781, 17853);

            GameObject newShip = Instantiate(enemy, spawnPosition, transform.rotation);
            newShip.transform.SetParent(transform);
            Transform shipText = newShip.transform.Find("Text");
            TextMesh meshComponent = shipText.gameObject.GetComponent<TextMesh>();
            meshComponent.text = ""+Random.Range(0, 64);
            Debug.Log("spawner at "+transform.position.x+" ship at "+newShip.transform.position.x);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}