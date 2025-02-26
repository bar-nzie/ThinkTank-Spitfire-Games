using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private WaveSpawner _waveSpawner;
    private Wave _wave;

    private int _currentWave;

    private float countdown = 5f;


    private void Start()
    {
        _waveSpawner = GetComponent<WaveSpawner>();
        _wave = GetComponent<Wave>();

        _currentWave = _waveSpawner.currentWaveIndexGetter();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Destroy(gameObject);

            _waveSpawner.waves[_waveSpawner.currentWaveIndex].enemiesLeft--;
        }

    }
}
