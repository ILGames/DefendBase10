using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public Spawner spawner;
    

    public void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Hurtbox triggred" + other);

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
        Destroy(buildings);
    }
}
