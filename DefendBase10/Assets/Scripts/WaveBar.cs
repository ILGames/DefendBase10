using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    private Slider slider;
    private float waveProgress = 0;
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
        waveProgress = newprogress;
        //Debug.Log("This is " + waveProgress);
        if (slider.value < waveProgress)
            slider.value += Time.deltaTime;
    }
}
