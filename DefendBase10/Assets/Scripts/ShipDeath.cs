using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipDeath : MonoBehaviour
{
    public bool dying = false;
    private SpriteSheet sheet;

    public void Start()
    {
                
        //GameObject explosion = GameObject.Find("Explosion");
        //explosion.SetActive(true);
        
        sheet = gameObject.GetComponentInChildren<SpriteSheet>();
        sheet.Frame = 79;   // can't se it on frame 79
    }
    public void Die()
    {
        dying = true;
        StartCoroutine(destroySelf());
        gameObject.GetComponent<FallScript>().enabled = false;
        Transform form = transform.Find("form");
        transform.Find("particles").gameObject.SetActive(true);
        form.DOLocalRotate(new Vector3(0, 0, 600), 2f, RotateMode.FastBeyond360);
        float xPos = transform.position.x;
        //Debug.Log("Ship at " + xPos);
        transform.DOMove(new Vector3(xPos > 0? xPos + 500 : xPos - 500, transform.position.y + 400, transform.position.z), 2f);
        StartCoroutine(Boom());
    }
    IEnumerator Boom()
    {
        sheet.Frame = 0;
        while(sheet.Frame < 80)
        {
            yield return new WaitForFixedUpdate();
            sheet.Frame++;
        }
        
    }
    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
