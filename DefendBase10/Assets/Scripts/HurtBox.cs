using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        List children = new List(GameObject);
        Transform[] building = gameObject.GetComponentsInChildren<Transform>();
        if (building == null)
            return children;
        foreach (Transform t in building)
        {
            if (t != null && t.gameobject != null)
                children.Add(t.gameobject);
        }

        return children;

        GameObject buildings = children[Random.Range(0, children)];
        buildings.Destroy();
    }
}
