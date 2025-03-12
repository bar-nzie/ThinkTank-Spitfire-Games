using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private float WaveCountdown = 1;

    [SerializeField] private GameObject spawnPoint;

    [SerializeField] public Wave[] waves;

    public int currentWaveIndex = 0;
    private bool readyToCountDown;

    public int currentWaveIndexGetter()
    {
        return currentWaveIndex;
    }

    // Start is called before the first frame update
    void Start()
    {

        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
        
    }

    // Update is called once per frame
    private void Update()
    {

        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("Reached end of waves");
            return;
        }

        if (readyToCountDown == true)
        {
            WaveCountdown -= Time.deltaTime;
        }

        if (WaveCountdown < 0 )
        {
            readyToCountDown = false;
            WaveCountdown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }

        if (waves[currentWaveIndex].enemiesLeft == 0)
        {
            readyToCountDown = true;
            currentWaveIndex++;
        }
        
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);

                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }

    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}

