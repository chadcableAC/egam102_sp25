using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector2 moveDirection = Vector2.right;

    Vector2 distanceMoved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = moveDirection * moveSpeed * Time.deltaTime;
        distanceMoved += (Vector2) offset;

        transform.position += offset;
    }
}
