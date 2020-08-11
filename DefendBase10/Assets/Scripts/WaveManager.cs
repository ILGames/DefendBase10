using System.Collections;
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
    }
    public Wave wave;

    public WaveBar waveBar;
    public Spawner spawner;
    public Wave[] waves;
    //Store index of the wave we want to be creating next
    private int currentWave = 0;

    public float waveCountdown;
    public float timeBetweenWaves = 4f;
    private float progress;
    public WaveText waveText;
    public ButtonAppear buttonAppear;
    public FirstAnimation firstAnimation;
    public SecondTransition secondTransition;
    public ThirdAnimation thirdAnimation;
    public FourthAnimation fourthAnimation;
    public FifthAnimation fifthAnimation;
    public SixthAnimation sixthAnimation;
    public float level_text;
    public GameObject firstText, secondText, thirdText, fourthText, fifthText;
    public Dialogue dialogue;
    public Dialogue2 dialogue2;
    public Dialogue3 dialogue3;
    public Dialogue4 dialogue4;
    public Dialogue5 dialogue5;
    public bool switchy;


    void Start()
    {
        StartWave();
        wave.level = 0;
    }
    void Update()
    {
        progress = waveCountdown;
        level_text = wave.level;

        if (waveCountdown <= 0)
        {
            WaveCompleted();
        }
        if (level_text == 0)
        {
            spawner.StopSpawning();
            waveBar.Stop();
            switchy = false;
            firstText.SetActive(true);
        }
        if(dialogue.text == false)
        {
            firstSetActive();
            switchy = true;
            spawner.StartSpawning();
            waveBar.Update();
        }
        if (level_text == 1)
        {
            spawner.StopSpawning();
            secondText.SetActive(true);
        }
        if (dialogue2.text == false)
        {
            secondSetActive();
        }
        if (level_text == 3)
        {
            spawner.StopSpawning();
            thirdText.SetActive(true);
        }
        if (dialogue3.text == false)
        {
            thirdSetActive();
        }
        if (level_text == 10)
        {
            spawner.StopSpawning();
            fourthText.SetActive(true);
        }
        if (dialogue4.text == false)
        {
            fourthSetActive();
        }
        if (level_text == 26)
        {
            spawner.StopSpawning();
            fifthText.SetActive(true);
        }
        if (dialogue5.text == false)
        {
            fifthSetActive();
        }
    }
    void WaveCompleted()
    {
        Debug.Log("wave Completed! " + currentWave);

        spawner.StopSpawning();
        waveCountdown = waves[currentWave].lengthOfTime;
        progress = waves[currentWave].lengthOfTime;
        wave.level += 1;

        if (currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
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

    IEnumerator waitToBeginNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
        waveBar.Update();
    }

    public Wave getCurrentWave()
    {
        return waves[currentWave];
    }
    public void firstSetActive()
    {
        firstText.SetActive(false);
    }
    public void secondSetActive()
    {
        secondText.SetActive(false);
    }
    public void thirdSetActive()
    {
        thirdText.SetActive(false);
    }
    public void fourthSetActive()
    {
        fourthText.SetActive(false);
    }
    public void fifthSetActive()
    {
        fifthText.SetActive(false);
    }
}
