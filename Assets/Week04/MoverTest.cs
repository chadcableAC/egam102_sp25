using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTest : MonoBehaviour
{
    // I want to move one unit to the right every second
    public Vector2 moveDirection = Vector2.right;
    public float moveStrength = 1;

    public bool usesDeltaTime = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is the correct way to move objects in an update loop
        if (usesDeltaTime)
        {
            // I want to move 1/60th unit to the right every frame
            Vector3 offset = moveStrength * moveDirection * Time.deltaTime;
            transform.position += offset;
        }
        // This is the WRONG way
        else
        {
            Vector3 offset = moveStrength * moveDirection;
            transform.position += offset;
        }
    }
}
