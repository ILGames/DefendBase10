using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    private Slider slider;
    public WaveManager wavemanager;
    public float newprogress;


    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
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
}
