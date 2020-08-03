using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveBar : MonoBehaviour
{
    private Slider slider;
    private float waveProgress = 0;
    public float FillSpeed = 0.5f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value < waveProgress)
            slider.value += FillSpeed * Time.deltaTime;
    }
    //Adds the progress to the bar
    public void IncrementProgress(float newprogress)
    {
        waveProgress = slider.value + newprogress;
    }
}
