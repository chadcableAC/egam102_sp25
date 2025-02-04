using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    // List of positions to spawn at
    public List<Transform> spawnPositions;

    // List of enemy prefabs to spawn
    public List<SimpleEnemy> enemyPrefabs;

    // How many enemies we should spawn
    public int numberOfEnemies = 3;

    // A list of enemies spawned by this script
    List<SimpleEnemy> allEnemies = new();

    void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        // See if the enemies have all been destoryed
        // Start by assuming this is true - we'll use the list to validate
        bool isEmpty = true;

        // Go through all of the enemies in the list
        foreach (SimpleEnemy enemy in allEnemies)
        {
            // If this enemy exists (in not null), this list still has valid enemies
            if (enemy != null)
            {
                // This list is NOT empty, so set it to false and stop the loop
                isEmpty = false;
                break;
            }
        }

        // If the list is empty, the game has been completed
        if (isEmpty)
        {
            Debug.Log("Game over");
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Let's pick an enemy to create
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
            SimpleEnemy prefab = enemyPrefabs[randomEnemyIndex];

            // Let's pick a position to spawn at
            int randomPositionIndex = Random.Range(0, spawnPositions.Count);
            Transform position = spawnPositions[randomPositionIndex];

            // Remove this position from the list so that we don't double spawn
            // at the same location
            spawnPositions.RemoveAt(randomPositionIndex);

            // Finally let's make a enemy!
            SimpleEnemy newEnemy = Instantiate(prefab);
            newEnemy.transform.position = position.position;

            // Track this enemy by adding it to our list
            allEnemies.Add(newEnemy);
        }
    }
}
