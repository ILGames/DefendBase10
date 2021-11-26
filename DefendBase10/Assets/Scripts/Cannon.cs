using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using DG.Tweening;

public class Cannon : MonoBehaviour
{
    public Transform spawner;
    public Transform pivot;
    public float startWait = 2f;
    public float fireWait = 5f;
    public float beamWait = 1f;
    public CannonBar bar;
    public GameObject Beam;
    public Light BeamLight;
    private Animator animator;

    private bool stopped = true;
    private AudioSource audioSource;
    public AudioClip blastSound;
    public AudioClip deploySound;
    public AudioClip collapseSound;

    void Start()
    {
        StartCoroutine(waitFire());
        Beam.SetActive(false);
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 0f;
        audioSource = GetComponent<AudioSource>();
    }
    public void Stop()
    {
        stopped = true;
    }

    void Update()
    {

    }

    public void Show()
    {
        audioSource.clip = deploySound;
        audioSource.Play();
        stopped = false;
        animator.speed = 1;
        animator.SetFloat("Direction", 1f);
        animator.Play("Take 001", 0, 0f);
    }
    public void Hide()
    {
        StartCoroutine(DelayedHide());
    }
    public void Fire()
    {
        GameObject ctrlPanel = GameObject.Find("ControlPanel");
        ToggleButtonManager buttonValue = ctrlPanel.GetComponent<ToggleButtonManager>();
        //Debug.Log("Button ="+buttonValue.buttonValue);

        bar.ResetBar();


        float lowY = 999999999;
        GameObject lowest = null;

        foreach (Transform child in spawner)
        {
            if (child.gameObject.name == "" + buttonValue.buttonValue)
            {
                if (child.position.y < lowY && child.position.y > transform.position.y)
                {
                    lowest = child.gameObject;
                    lowY = child.position.y;
                }
            }
        }
        if (lowest != null)
        {
            Vector3 shipPos = lowest.transform.position;
            Vector3 cannonPos = pivot.transform.position;
            shipPos.z = 0;
            cannonPos.z = 0;
            Vector3 cannon2ShipVector = shipPos - cannonPos;
            cannon2ShipVector.Normalize();
            Quaternion cannonRot = Quaternion.LookRotation(-Vector3.forward, cannon2ShipVector);
            pivot.transform.rotation = cannonRot;
            Beam.SetActive(true);
            audioSource.clip = blastSound;
            audioSource.Play();
            StartCoroutine(waitBeam());
            
            KillShip(lowest);

            // TODO animate light intensity to make it flash
           AnimateLight();
        }
    }
    void AnimateLight()
    {
        BeamLight.intensity = 50f;
        DOTween.To(
            () => BeamLight.intensity,
            (value) => {
                BeamLight.intensity = value;
            },
            0f,
            1
        );
        BeamLight.range = 0f;
        DOTween.To(
            () => BeamLight.range,
            (value) => {
                BeamLight.range = 750 * Mathf.Sin(Mathf.PI * 2 * value );
            },
            1f,
            1
        );
        //DOVirtual.DelayedCall(2, AnimateBanner);
    }
    public void Reset()
    {
        pivot.transform.rotation = Quaternion.LookRotation(-Vector3.forward, Vector3.up);
    }
    IEnumerator waitBeam() 
    {
        Beam.SetActive(true);

        yield return new WaitForSeconds(beamWait);

        Beam.SetActive(false);
    }
    
    IEnumerator waitFire()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            if(!stopped)    Fire();

            yield return new WaitForSeconds(fireWait);
        }
    }

    public void KillShip(GameObject ship)
    {
        ship.GetComponent<ShipDeath>().Die();
    }

    IEnumerator DelayedHide()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = collapseSound;
        audioSource.Play();
        Reset();
        animator.speed = 1;
        animator.SetFloat("Direction", -1f);
        animator.Play("Take 001", 0, 1f);
    }
 }

