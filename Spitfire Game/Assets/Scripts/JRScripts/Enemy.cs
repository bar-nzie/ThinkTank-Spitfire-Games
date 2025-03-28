using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private WaveSpawner _waveSpawner;


    private float DeathCountdown = 5.0f;


    private void Start()
    {
        _waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * -speed * Time.deltaTime);

        DeathCountdown -= Time.deltaTime;

        if (DeathCountdown <= 0)
        { 
            Destroy(gameObject);
        }

    }
}
