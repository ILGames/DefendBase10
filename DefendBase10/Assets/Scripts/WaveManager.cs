﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class WaveManager : MonoBehaviour
{


    [System.Serializable]
    public class Wave
    {
        //Reference to prefab we want to instantiate at our spawnpoints
        public Transform enemy;
        public float lengthOfTime;
        public int level;
        public int digits;
        public float maxspawn;
        public float minspawn;
        public bool isDialogue;
        public Dialogue dialogue;
    }

    public WaveBar waveBar;
    public Spawner spawner;
    public Wave[] waves;
    //Store index of the wave we want to be creating next
    private int currentWave = 0;

    public float waveCountdown;
    public float timeBetweenWaves = 4f;
    public WaveText waveText;
    public ButtonAppear buttonAppear;
    public FirstAnimation firstAnimation;
    public SecondTransition secondTransition;
    public ThirdAnimation thirdAnimation;
    public FourthAnimation fourthAnimation;
    public FifthAnimation fifthAnimation;
    public SixthAnimation sixthAnimation;
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;
    public Dialogue dialogue5;

    public 


    void Start()
    {
        StartWave();
    }
    void Update()
    {
        waveCountdown -= Time.deltaTime;

        if (waveCountdown <= 0 && !waves[currentWave].isDialogue)
        {
            WaveCompleted();
        }
        else if (waves[currentWave].isDialogue && !waves[currentWave].dialogue.text)
        {

            WaveCompleted();
        }
    }
    void WaveCompleted()
    {
        Debug.Log("wave Completed! " + currentWave);

        spawner.StopSpawning();

        if (currentWave + 1 > waves.Length - 1)
        {
            Debug.Log("Completed all waves!");
            waveCountdown = float.PositiveInfinity;
            spawner.StopSpawning();
        }
        else
        {
            StartCoroutine(waitToBeginNextWave());
            currentWave++;
        }

    }

    void StartWave()
    {
        waveCountdown = waves[currentWave].lengthOfTime;
        //TODO: Tell Spawner how fast to spawn, etc.
        if (!waves[currentWave].isDialogue)
        {
            Debug.Log("Starting Ship Wave");
            spawner.StartSpawning();
            waveBar.ResetBar(waveCountdown);
            waveText.ResetText();
            buttonAppear.ResetDigits();
            firstAnimation.ResetDigits();
            secondTransition.ResetDigits();
            thirdAnimation.ResetDigits();
            fourthAnimation.ResetDigits();
            fifthAnimation.ResetDigits();
            sixthAnimation.ResetDigits();
        }
        else
        {
            Debug.Log("Starting Dialogue "+ waves[currentWave].dialogue.gameObject.transform.parent.gameObject.name);
            waves[currentWave].dialogue.gameObject.transform.parent.gameObject.SetActive(true);
        }
    }

    IEnumerator waitToBeginNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
        //waveBar.Update();
    }

    public Wave getCurrentWave()
    {
        return waves[currentWave];
    }
}
