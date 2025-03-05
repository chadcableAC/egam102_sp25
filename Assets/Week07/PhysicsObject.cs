using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public Rigidbody2D rb;

    public float forceStrength = 1;
    public ForceMode2D forceType;

    public GroundDetector detector;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    transform.position += Vector3.up * 5;
        //}
    }

    void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (detector != null)
            {
                if (detector.isGrounded)
                {
                    rb.AddForce(Vector2.up * forceStrength, forceType);
                }
            }
        }

        Vector2 runDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            runDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            runDirection.x = 1;
        }

        Vector2 newVelocity = rb.velocity;
        newVelocity.x = runDirection.x;
        rb.velocity = newVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter!");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay!");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit!");
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger Enter!");
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Trigger Stay!");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trigger Exit!");
    }
}
