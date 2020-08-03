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

    public Dictionary<int, List<GameObject>> ships;

    void Start()
    {
        ships = new Dictionary<int, List<GameObject>>();
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
            ShipValue valueScript = newShip.GetComponent<ShipValue>();
            valueScript.RandomizeValue(64);
            if (ships.ContainsKey(valueScript.value))
            {
                ships[valueScript.value].Add(newShip);
            }
            else
            {
                ships[valueScript.value] = new List<GameObject>() { newShip };
            }
            newShip.name = "" + valueScript.value;
            Debug.Log("new ship # = "+ valueScript.value);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}