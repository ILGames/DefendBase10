using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class CannonBar : MonoBehaviour
{
    private Slider slider;
    public float newprogress;
    public bool stopped = true;
    
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if (!stopped)
        {
            newprogress += Time.deltaTime;
            slider.value = slider.minValue + newprogress;
        }
    }

    public void ResetBar()
    {
        newprogress = 0;  
    }
    public void Stop()
    {
        stopped = true;
        slider.value = 0;
        newprogress = 0;
    }
    public void Start()
    {
        stopped = false;
    }
}