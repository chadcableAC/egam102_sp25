using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveStrength = 1;
    public float jumpStrength = 1f;

    public GroundDetector groundDetector;

    void FixedUpdate()
    {
        float horizontal = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }

        Vector2 newVelocity = rb.velocity;
        newVelocity.x = horizontal * moveStrength;
        rb.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.UpArrow) &&
            groundDetector.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }
}
