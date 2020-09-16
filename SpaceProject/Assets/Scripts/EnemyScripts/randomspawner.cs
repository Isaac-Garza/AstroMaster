using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomspawner : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5;

    public float spawnRate = 2f;
    float nextSpawn = 0f;
    int whatToSpawn;


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);
            Debug.Log(whatToSpawn);


            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(enemy1, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy2, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemy3, transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(enemy4, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(enemy5, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
