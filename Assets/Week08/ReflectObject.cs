using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectObject : MonoBehaviour
{
    public Rigidbody2D rb;

    // Math values
    public float speed;
    public Vector2 currentDirection;

    void Start()
    {
        // Set the initial direction
        currentDirection = transform.up;
    }

    void FixedUpdate()
    {
        // Debug coloring
        Color rayColor = Color.white;

        // Math values
        Vector3 direction = currentDirection;
        float rayDistance = 2;        

        // Look for all hits
        RaycastHit2D[] hitInfos = Physics2D.RaycastAll(transform.position, direction, rayDistance);
        foreach (RaycastHit2D hitInfo in hitInfos)
        {
            // Ignore ourselves
            if (hitInfo.rigidbody != rb)
            { 
                // We hit something!
                rayColor = Color.red;

                // Find the normal, debug draw
                Vector3 normal = hitInfo.normal;
                Debug.DrawRay(hitInfo.point, normal, Color.yellow);

                // Lets turn our variables into the math equation
                Vector2 d = direction;
                Vector2 n = normal.normalized;
                Vector2 r = d - 2 * Vector2.Dot(d, n) * n;

                // Debug draw this new direction
                Debug.DrawRay(hitInfo.point, r, Color.magenta);

                // Don't look at anymore collisions
                break;
            }
        }

        // Debug draw the direction
        Debug.DrawRay(transform.position, direction * rayDistance, rayColor);

        // Update our velocity every frame
        rb.velocity = currentDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 normal = collision.GetContact(0).normal;

        // Lets turn our variables into the math equation
        Vector2 d = currentDirection;
        Vector2 n = normal.normalized;
        Vector2 r = d - 2 * Vector2.Dot(d, n) * n;

        currentDirection = r.normalized;
    }
}
