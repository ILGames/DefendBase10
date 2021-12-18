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
        public float shipSpeed = 1;
        public float cannonCooldown = 5f;
        public float maxspawn;  // TODO - unused, delete or use
        public float minspawn;  // TODO - unused, delete or use
        public bool isDialogue;
        public Dialogue dialogue;
    }

    public WaveBar waveBar;
    public Spawner spawner;
    public CannonBar cannonBar;
    public GameObject tutorialHighlight;
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

    public Cannon cannon;
    public Animator cannon_animator;
    public ControlPanel control_panel;



    void Start()
    {
        if(TitleScene.cont && PlayerPrefs.HasKey("wave"))
        {
            currentWave = PlayerPrefs.GetInt("wave");
        }
        StartWave();
        cannon_animator.speed = 0f;
    }
    void Update()
    {
        waveCountdown -= Time.deltaTime;

        if (waveCountdown <= 0 && !waves[currentWave].isDialogue)
        {
            WaveCompleted();
        }
        else if (waves[currentWave].isDialogue && !waves[currentWave].dialogue.notFinished)
        {
            // mark wave as no longer a dialogue and restart it - this used to also call WaveCompleted(), TODO check this more thoroughly
            waves[currentWave].isDialogue = false;
            StartWave();
        }
    }
    void WaveCompleted()
    {
        Debug.Log("wave Completed! " + currentWave);
        
        // hide the cannon after each wave (none dialogue)
        if(!waves[currentWave].isDialogue)
        {
            cannon.Stop();
            cannon.Hide();
            cannonBar.Stop();
            //cannon_animator.speed = 1;
            //cannon_animator.SetFloat("Direction", -1f);
            //cannon_animator.Play("Take 001", 0, 1f);
        }

        spawner.StopSpawning();
        waveCountdown = float.PositiveInfinity;
        if (currentWave + 1 > waves.Length - 1)
        {
            Debug.Log("Completed all waves!");
        }
        else
        {
            StartCoroutine(waitToBeginNextWave());
            currentWave++;
            PlayerPrefs.SetInt("wave", currentWave);
        }
    }

    void StartWave()
    {
        int totalGameWaves = 0;
        for (int i = 0; i <= currentWave; i++)
        {
            if(!waves[i].isDialogue) totalGameWaves++;
        }
        waveText.ResetText(totalGameWaves);

        Wave wave = waves[currentWave];
        waveCountdown = wave.lengthOfTime;
        //TODO: Tell Spawner how fast to spawn, etc.
        if (!wave.isDialogue)
        {
            Debug.LogFormat("Starting Wave {0}, speed {1}", currentWave, wave.shipSpeed);
            //cannon_animator.Play("Take 001", -1, 0f);
            spawner.StartSpawning(wave);
            waveBar.ResetBar(waveCountdown);

            if (wave.cannonCooldown != 0)
            {
                cannon.fireWait = wave.cannonCooldown;
                cannonBar.SetMax(wave.cannonCooldown);
            }
            cannonBar.ResetBar();
            cannonBar.Start();
            buttonAppear.ResetDigits();
            firstAnimation.ResetDigits();
            secondTransition.ResetDigits();
            thirdAnimation.ResetDigits();
            fourthAnimation.ResetDigits();
            fifthAnimation.ResetDigits();
            sixthAnimation.ResetDigits();

            control_panel.Next(wave);

            cannon.Show();
            //cannon_animator.speed = 1;
            //cannon_animator.SetFloat("Direction", 1f);
            //cannon_animator.Play("Take 001", 0, 0f);
            if (currentWave==0)
            {
                StartCoroutine(WaitForBlink(5));
            }
        }
        else
        {
            
            cannonBar.Stop();
            Debug.Log("Starting Dialogue "+ wave.dialogue.gameObject.transform.parent.gameObject.name);
            wave.dialogue.gameObject.transform.parent.gameObject.SetActive(true);
        }
    }

    IEnumerator waitToBeginNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
        waveBar.Update();
    }

    IEnumerator WaitForBlink(uint times)
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(BlinkHighlight(times));
    }

    IEnumerator BlinkHighlight(uint times)
    {
        if (times > 0)
        {
            tutorialHighlight.SetActive(true);
            yield return new WaitForSeconds(0.75f);
            tutorialHighlight.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(BlinkHighlight(times - 1));
        }

    }

    public Wave getCurrentWave()
    {
        return waves[currentWave];
    }
}
