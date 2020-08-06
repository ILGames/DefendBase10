using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{ 


    [System.Serializable]
    public class Wave
    {
        public string name;
        //Reference to prefab we want to instantiate at our spawnpoints
        public Transform enemy;
        public float lengthOfTime;
        public int level;
        public int digits;
        public float maxspawn;
        public float minspawn;
    }
    public WaveBar waveBar;
    public Spawner spawner;
    public Wave[] waves;
    //Store index of the wave we want to be creating next
    private int currentWave = 0;

    //Stores wave countdown timer
    public float waveCountdown;
    public float timeBetweenWaves = 4f;
    public float progress;

    void Start()
    {
        StartWave();
    }
    void Update()
    {

        waveCountdown -= Time.deltaTime;
        progress = waveCountdown;
        if(waveCountdown <= 0)
        {
            WaveCompleted();
        }
    }
    void WaveCompleted()
    {
        Debug.Log("wave Completed! "+ currentWave);

        spawner.StopSpawning();
        waveCountdown = waves[currentWave].lengthOfTime;
        progress = waves[currentWave].lengthOfTime;

        if (currentWave + 1 > waves.Length -1)
        {
            currentWave = 0;
            Debug.Log("Completed all waves!");
            waveCountdown = float.PositiveInfinity;
            spawner.StopSpawning();
            //Add cutscene
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
    }

    IEnumerator waitToBeginNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
    }

    public Wave getCurrentWave()
    {
        return waves[currentWave];
    }
}
