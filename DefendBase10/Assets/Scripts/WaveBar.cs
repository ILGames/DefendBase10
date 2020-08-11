using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    private Slider slider;
    public float newprogress;
    public WaveManager waveManager;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void Update()
    {

        newprogress -= Time.deltaTime;
        //Debug.Log("This is " + newProgress);
        slider.value = slider.maxValue - newprogress;

    }

    public void ResetBar(float newMax)
    {
        slider.value = 0;
        slider.maxValue = newMax;
        newprogress = newMax;
    }

    public void Stop()
    {
        slider.value = 0;
        newprogress = 0;
    }
}
