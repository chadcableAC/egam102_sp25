using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingRb : MonoBehaviour
{
    public Rigidbody2D rb;

    public SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color color = Color.white;
        if (rb.IsSleeping())
        {
            color = Color.grey;
        }
        rend.color = color;

        if (Input.GetMouseButtonDown(0))
        {
            rb.WakeUp();
        }
    }
}
