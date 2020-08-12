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
    
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        newprogress += Time.deltaTime;
        slider.value = slider.minValue + newprogress;
    }

    public void ResetBar()
    {
        newprogress = 0;  
    }
}