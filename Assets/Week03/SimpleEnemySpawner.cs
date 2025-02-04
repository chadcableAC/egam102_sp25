using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPositions;
    public List<SimpleEnemy> enemyPrefabs;

    public int numberOfEnemies = 3;

    List<SimpleEnemy> allEnemies = new();



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        bool isEmpty = true;
        foreach (SimpleEnemy enemy in allEnemies)
        {
            if (enemy != null)
            {
                isEmpty = false;
                break;
            }
        }

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

            spawnPositions.RemoveAt(randomPositionIndex);

            // Finally let's make a enemy!
            SimpleEnemy newEnemy = Instantiate(prefab);
            newEnemy.transform.position = position.position;

            allEnemies.Add(newEnemy);
        }
    }
}
