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
        // Spawn every x seconds
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnFrequency)
        {
            spawnTimer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        // The number of times we can try before giving up
        float attempts = maxAttempts;

        for (int i = 0; i < attempts; i++)
        {
            // Pick a random position in the range
            Vector2 randomPosition = Vector2.zero;
            randomPosition.x = Random.Range(-spawnArea.x, spawnArea.x);
            randomPosition.y = Random.Range(-spawnArea.y, spawnArea.y);

            // If we're overlapping something, try again
            if (Physics2D.OverlapCircle(randomPosition, spawnRadius))
            {
                Debug.Log("Found overlapping position at " + randomPosition + ", trying again");
            }
            // Otherwise make the object and "break" out of the loop
            else
            {
                GameObject newObj = Instantiate(spawnPrefab);
                newObj.transform.position = randomPosition;

                break;
            }
        }
        // "break;" takes us here
    }
}
