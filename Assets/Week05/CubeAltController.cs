using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAltController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // Set the parameter on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("OnJump");
        }
    }
}
