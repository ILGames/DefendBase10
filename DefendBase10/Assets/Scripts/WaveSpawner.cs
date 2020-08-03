using System.Collections;
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
        public int count;
        public float rate;
        public int level;
        public int digits;
        public float maxspawn;
        public float minspawn;
    }
    public Wave[] waves;
    //Store index of the wave we want to be creating next
    private int nextWave = 0;

    //Stores time between waves
    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }
    void Update()
    {
        //Gives the player a chance to kill off all enemies
        if (state == SpawnState.WAITING)
        {
            //Check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }

        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
        
    }
    void WaveCompleted()
    {
        Debug.Log("wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves!");
            //Add cutscene
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        { 
            searchCountdown = 1f;
            //Finds object with tag "Enemy"
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
        //Spawn an enemy method
        SpawnEnemy(_wave.enemy);
        yield return new WaitForSeconds(1f/ _wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        //Instantiates enemy
        Debug.Log("Spawning Enemy:" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
            
    }
}
