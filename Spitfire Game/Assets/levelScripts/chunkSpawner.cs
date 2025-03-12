using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunkSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float chunkInterval = 5f;
    private float timer;
    private float minX = -100f;
    private float maxX = 100f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > chunkInterval)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            float randomX = Random.Range(minX, maxX);

            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            Instantiate(prefab[randomIndex], spawnPosition, Quaternion.identity);
            timer = 0;
        }
    }
}
