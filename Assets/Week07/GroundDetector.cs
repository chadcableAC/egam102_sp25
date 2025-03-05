using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public float distance = 1;

    public SpriteRenderer rend;

    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        isGrounded = false;

        Color color = Color.white;

        RaycastHit2D[] hitInfos = Physics2D.RaycastAll(transform.position, Vector2.down, distance);
        foreach (RaycastHit2D info in hitInfos)
        {
            if (info.collider.gameObject != gameObject)
            {                
                Debug.Log(info.collider.gameObject);
                color = Color.red;

                isGrounded = true;
            }
        }

        rend.color = color;

        Debug.DrawRay(transform.position, Vector2.down * distance, color);
    }
}
