using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTest : MonoBehaviour
{
    public Vector2 moveDirection = Vector2.right;
    public float moveStrength = 1;

    public bool usesDeltaTime = false;

    void Update()
    {
        // This is the correct way to move objects in an update loop
        // This code works at any framerate on any platform
        if (usesDeltaTime)
        {
            Vector3 offset = moveStrength * moveDirection * Time.deltaTime;
            transform.position += offset;
        }
        // This is the WRONG way
        // This code will NOT work the same at different framerates
        else
        {
            Vector3 offset = moveStrength * moveDirection;
            transform.position += offset;
        }
    }
}
