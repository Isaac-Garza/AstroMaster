using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavespawner : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting}

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        //public Transform enemy2;
        //public Transform enemy3;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
 
    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

   private SpawnState state = SpawnState.Counting;

   public scorescreenscript _scoreScript;


    void Start ()
    {
        

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn points referenced");
        }


        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
            
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                _scoreScript.OpenScoreScreen();
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted ()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {

            _scoreScript.OpenScoreScreen();

            //nextWave = 0; 
            //new scene, next level of waves, shop screen, stat multiplier....
            Debug.Log("Completed All Waves! Looping...");
        }
        else
        {
            nextWave++;
        }

        
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave;" + _wave.name);
        state = SpawnState.Spawning;
        
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            //SpawnEnemy2(_wave.enemy);
            //SpawnEnemy3(_wave.enemy);
            yield return new WaitForSeconds( 1f/_wave.rate );
        }


        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        Debug.Log("Spawning Enemy" + _enemy.name);


        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }
    //void SpawnEnemy2(Transform _enemy2)
   // {
       // Debug.Log("Spawning Enemy" + _enemy2.name);


        //Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //Instantiate(_enemy2, _sp.position, _sp.rotation);

    //}
    //void SpawnEnemy3(Transform _enemy3)
   // {
       // Debug.Log("Spawning Enemy" + _enemy3.name);


        //Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        //Instantiate(_enemy3, _sp.position, _sp.rotation);

    //}

}
