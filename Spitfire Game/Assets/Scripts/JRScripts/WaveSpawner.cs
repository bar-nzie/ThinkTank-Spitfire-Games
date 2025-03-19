using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoint;

    [SerializeField] GameObject[] enemyTypeList;

    [SerializeField] int numberOfEnemiesInWave;
    [SerializeField] int numberOfWaves;
    [SerializeField] int currentWaveIndex = 0;

    [SerializeField] float timeToNextEnemy;
    [SerializeField] float timeToNextWave;

    int spawnedEnemies;
    int randomSpawn;

    bool isSpawningWave = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayWaveSpawn());
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentWaveIndex > numberOfWaves)
        {
            Debug.Log("You Win");
        }

    }

    private void SpawnEnemiesInWave()
    {
        Debug.Log(spawnedEnemies);
        if (currentWaveIndex < numberOfWaves) { 
            if (spawnedEnemies < numberOfEnemiesInWave)
            {
                SpawnAnEnemy();
                spawnedEnemies++;
                StartCoroutine(DelayEnemySpawn());
            }
            else
            {
                StartCoroutine(DelayWaveSpawn());

            }
        }

    }

    private IEnumerator DelayEnemySpawn()
    {
        yield return new WaitForSeconds(timeToNextEnemy);
        SpawnEnemiesInWave();
    }

    private IEnumerator DelayWaveSpawn()
    {
        yield return new WaitForSeconds(timeToNextWave);

        spawnedEnemies = 0;
        currentWaveIndex++;
        SpawnEnemiesInWave();
    }

    private int spawnPointPicker()
    {
        randomSpawn = Random.Range(0, spawnPoint.Length);
        return randomSpawn;
    }

    private void SpawnAnEnemy()
    {
        spawnPointPicker();
        int randomEnemy = Random.Range(0, enemyTypeList.Length);
        Instantiate(enemyTypeList[randomEnemy], new Vector3(spawnPoint[randomSpawn].transform.position.x, spawnPoint[randomSpawn].transform.position.y, spawnPoint[randomSpawn].transform.position.z), Quaternion.identity);
    }
}




