﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using DG.Tweening;

public class BuildingDie : MonoBehaviour
{
    public Transform spawner;

    List<GameObject> excluded;

    float buildingKillCooldown = 0;

    void Start()
    {
        excluded = new List<GameObject>();
    }

    void Update()
    {
        CheckIfBuildingShouldDie();
        buildingKillCooldown -= Time.deltaTime;
    }

    public GameObject ChooseBuildingToKill()
    {
        List<GameObject> children = new List<GameObject>();
        Transform[] buildings = gameObject.GetComponentsInChildren<Transform>();

        GameObject markedForDeath = null;
        float randomVal = Random.value;
        int counter = 1;

        List<Transform> included = new List<Transform>();
        foreach (Transform child in buildings)
        {
            if (!excluded.Contains(child.gameObject))
            {
                included.Add(child);
            }
        }

        foreach (Transform child in included)
        {
            if (randomVal < counter * (1f / (float)included.Count))
            {
                markedForDeath = child.gameObject;
                break;
            }
            counter++;
        }
        return markedForDeath;
    }

    void CheckIfBuildingShouldDie()
    {
        
        foreach (Transform child in spawner)
        {
            if (child.transform.localPosition.y < -1278.0 && buildingKillCooldown <= 0)
            {
                Debug.Log("Ship Below Line");
                GameObject doomed = ChooseBuildingToKill();
                Kill(doomed);
                child.gameObject.GetComponent<ShipDeath>().Die();
            }
        }
    }

    void Kill(GameObject doomed)
    {
        buildingKillCooldown = 1f;
        excluded.Add(doomed);
        Debug.Log("Building Dying "+doomed.name);
        doomed.transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1000, transform.position.z), 3f);
    }

    public void ReviveRandom()
    {

    }

    void Revive(GameObject resurrected)
    {
        if (!excluded.Contains(resurrected))
        {
            return;
        }
        excluded.Remove(resurrected);
    }
}
