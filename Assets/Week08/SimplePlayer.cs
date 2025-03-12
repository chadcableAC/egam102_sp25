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
        // Get the left / right input
        float horizontal = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }

        // Take the current velocity
        Vector2 newVelocity = rb.velocity;

        // Udpate the X to our input
        newVelocity.x = horizontal * moveStrength;

        // Reassign the velocity
        rb.velocity = newVelocity;

        // Listen for jumps (make sure we're grounded)
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
            groundDetector.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }
}
