using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipRetreat : MonoBehaviour
{

    public void Retreat()
    {

        ShipDeath death = gameObject.GetComponent<ShipDeath>();
        if(death.dying) return;  

        StartCoroutine(destroySelf());
        gameObject.GetComponent<FallScript>().enabled = false;
        float xPos = transform.localPosition.x;
        transform.DOLocalRotate(new Vector3(0, 0, xPos > 0 ? -30 : 30), 0.25f, RotateMode.FastBeyond360);
        // TODO calculate the require x value to guarantee being off screen
        transform.DOLocalMoveX(xPos > 0? xPos + 600 : xPos - 600, 2f).SetEase(Ease.OutCubic);
        transform.DOLocalMoveY(transform.localPosition.y + 500, 2f).SetEase(Ease.OutQuad);
    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
