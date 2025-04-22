using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoint;

    [SerializeField] GameObject[] enemyTypeList;
    [SerializeField] GameObject EndGameBanner;

    [SerializeField] int numberOfEnemiesInWave;
    [SerializeField] int numberOfWaves;
    [SerializeField] int currentWaveIndex = 0;

    [SerializeField] float timeToNextEnemy;
    [SerializeField] float timeToNextWave;

    private NarrationScript narration;

    int spawnedEnemies;
    int randomSpawn;

    // Start is called before the first frame update
    void Start()
    {
        narration = FindObjectOfType<NarrationScript>();

        if (narration == null)
        {
            Debug.LogError("NarrationScript not found in the scene!");
            return;
        }

        StartCoroutine(DelayWaveSpawn());

        EndGameBanner.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentWaveIndex > numberOfWaves)
        {
            //Debug.Log("You Win");
            EndGameBanner.gameObject.SetActive(true);

            Invoke("BackToMenu", 5.0f);
        }

    }

    private void SpawnEnemiesInWave()
    {
        Debug.Log(spawnedEnemies);
        if (currentWaveIndex <= numberOfWaves) {
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
        //Wait until narration is finished
        yield return new WaitUntil(() => !narration.factsArePlaying);

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

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}




