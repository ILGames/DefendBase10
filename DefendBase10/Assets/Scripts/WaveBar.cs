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
        slider.maxValue = Mathf.Abs(wavemanager.progress);
    }
    void Update()
    {
        newprogress = wavemanager.progress;
        //Debug.Log("This is " + newProgress);
        if (slider.value < newprogress)
            slider.value += Time.deltaTime;
    }
}
