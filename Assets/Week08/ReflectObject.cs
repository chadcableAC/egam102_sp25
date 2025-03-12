using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public Vector2 currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        currentDirection = transform.up;
    }

    void FixedUpdate()
    {
        rb.velocity = currentDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Color rayColor = Color.white;

        Vector3 direction = currentDirection;
        float rayDistance = 2;        

        RaycastHit2D[] hitInfos = Physics2D.RaycastAll(transform.position, direction, rayDistance);
        foreach (RaycastHit2D hitInfo in hitInfos)
        {
            if (hitInfo.rigidbody != rb)
            { 
                //
                rayColor = Color.red;

                Vector3 normal = hitInfo.normal;
                Debug.DrawRay(hitInfo.point, normal, Color.yellow);

                // Lets turn our variables into the math equation
                Vector2 d = direction;
                Vector2 n = normal.normalized;
                Vector2 r = d - 2 * Vector2.Dot(d, n) * n;

                Debug.DrawRay(hitInfo.point, r, Color.magenta);

                break;
            }
        }

        Debug.DrawRay(transform.position, direction * rayDistance, rayColor);
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
