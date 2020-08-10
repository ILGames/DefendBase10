using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipDeath : MonoBehaviour
{

    public void Die()
    {
        StartCoroutine(destroySelf());
        gameObject.GetComponent<FallScript>().enabled = false;
        Transform form = transform.Find("form");
        transform.Find("particles").gameObject.SetActive(true);
        form.DOLocalRotate(new Vector3(0, 0, 600), 2f, RotateMode.FastBeyond360);
        float xPos = transform.position.x;
        //Debug.Log("Ship at " + xPos);
        transform.DOMove(new Vector3(xPos > 2700? xPos + 400 : xPos - 400, transform.position.y + 400, transform.position.z), 2f);
    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
