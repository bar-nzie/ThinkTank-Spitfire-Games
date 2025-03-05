using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunkSpawner : MonoBehaviour
{
    public GameObject[] prefab;
    public float chunkInterval = 5f;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > chunkInterval)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            Instantiate(prefab[randomIndex], transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
