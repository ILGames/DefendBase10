using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class BuildingDie : MonoBehaviour
{
    public Transform spawner; 

    void BuildingList()
    {
        if (other.transform.parent != spawner)
        {
            return;
        }

        List<GameObject> children = new List<GameObject>();
        Transform[] building = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform t in building)
        {
            if (t != null && t.gameObject != null)
                children.Add(t.gameObject);
        }

        GameObject buildings = children[Random.Range(0, children.Count)];

        foreach (Transform child in spawner)
        {
            if (child.transform.position.y < gameobject.transform.position.y)
            {
                Destroy(buildings);
            }
        }
    }
}
