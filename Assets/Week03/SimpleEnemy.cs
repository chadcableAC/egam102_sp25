using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float timeToDestroy = 5;

    void Update()
    {
        // Destroy ourselves after the timer hits zero
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy < 0)
        {
            // Remember - destroy the GAMEOBJECT to delete the object
            Destroy(gameObject);
        }
    }
}
