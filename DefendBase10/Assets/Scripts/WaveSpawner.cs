﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //Store values 
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        //Reference to prefab we want to instantiate at our spawnpoints
        public Transform enemy;
        public float lengthOfTime;
        public float rate;
        public int level;
        public int digits;
        public float maxspawn;
        public float minspawn;
    }

    public Spawner spawner;
    public Wave[] waves;
    //Store index of the wave we want to be creating next
    private int currentWave = 0;

    //Stores wave countdown timer
    public float waveCountdown;
    public float timeBetweenWaves = 4f;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        StartWave();
    }
    void Update()
    {

        waveCountdown -= Time.deltaTime;
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

        state = SpawnState.COUNTING;

        if(currentWave + 1 > waves.Length -1)
        {
            currentWave = 0;
            Debug.Log("Completed all waves!");
            waveCountdown = float.PositiveInfinity;
            spawner.StopSpawning();
            //Add cutscene
        }
        else
        {
            currentWave++;
            StartCoroutine(waitToBeginNextWave());
        }
        
    }

    void StartWave()
    {
        waveCountdown = waves[currentWave].lengthOfTime;
        //TODO: Tell Spawner how fast to spawn, etc.
        spawner.StartSpawning();
    }

    IEnumerator waitToBeginNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
    }
}
