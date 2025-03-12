using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingRb : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer rend;

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
