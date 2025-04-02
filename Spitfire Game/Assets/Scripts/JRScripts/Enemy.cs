using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private WaveSpawner _waveSpawner;


    [SerializeField] float DeathCountdown = 7.0f;

    Vector3 enemyDespawnPoint;


    private void Start()
    {
        _waveSpawner = FindObjectOfType<WaveSpawner>();
        enemyDespawnPoint = new Vector3(transform.position.x, transform.position.y, -50);

    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(transform.forward * -speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, enemyDespawnPoint, speed * Time.deltaTime);

        DeathCountdown -= Time.deltaTime;

        if (Vector3.Distance(transform.position, enemyDespawnPoint) < 0.01f)
        { 
            Destroy(gameObject);

        }

    }
}
