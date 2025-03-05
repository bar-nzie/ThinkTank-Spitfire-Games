using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    public GameObject[] enemies;

    [SerializeField] public int numberOfWaves;
    public int numberOfEnemiesInWave;

    public int currentWaveIndex = 0;
    public float timeToNextEnemy;
    public float timeToNextWave;

    int spawnedEnemies;

    bool isSpawningWave = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayWaveSpawn());
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentWaveIndex >= numberOfWaves)
        {
            Debug.Log("You Win");
        }

    }

    private void SpawnEnemiesInWave()
    {
        currentWaveIndex++;
        if (spawnedEnemies <= numberOfEnemiesInWave)
        {
            spawnedEnemies++;
            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
            StartCoroutine(DelayEnemySpawn());
        } else
        {
            currentWaveIndex++;
            if (currentWaveIndex <= numberOfWaves)
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
        SpawnEnemiesInWave();
    }
}




