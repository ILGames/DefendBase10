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

    int maxNum = 2;

    ButtonsOnScreen buttonsShowing;

    void Start()
    {
        ships = new Dictionary<int, List<GameObject>>();
        StartCoroutine(waitSpawner());

        GameObject controlPanel = GameObject.Find("ControlPanel");
        buttonsShowing = controlPanel.GetComponent<ButtonsOnScreen>();
    }

    void Update()
    {
        
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            maxNum = 2^(buttonsShowing.buttonsAnimated-1);

            Vector3 spawnPosition = new Vector3(Random.Range(2456, spawnValues.x), 2781, 17853);

            GameObject newShip = Instantiate(enemy, spawnPosition, transform.rotation);
            newShip.transform.SetParent(transform);
            ShipValue valueScript = newShip.GetComponent<ShipValue>();
            valueScript.RandomizeValue(maxNum);
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

            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}