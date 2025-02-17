using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Vector2 spawnArea;

    public GameObject spawnPrefab;

    public float spawnRadius;

    public float spawnFrequency;
    float spawnTimer;

    public float maxAttempts = 100;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnFrequency)
        {
            spawnTimer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        float attempts = maxAttempts;

        for (int i = 0; i < attempts; i++)
        { 
            Vector2 randomPosition = Vector2.zero;
            randomPosition.x = Random.Range(-spawnArea.x, spawnArea.x);
            randomPosition.y = Random.Range(-spawnArea.y, spawnArea.y);

            if (Physics2D.OverlapCircle(randomPosition, spawnRadius))
            {
                Debug.Log("Found overlapping position at " + randomPosition + ", trying again");
            }
            else
            {
                GameObject newObj = Instantiate(spawnPrefab);
                newObj.transform.position = randomPosition;

                break;
            }
        }

        // Break takes us here
    }
}
