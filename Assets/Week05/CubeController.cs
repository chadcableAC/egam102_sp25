using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // Set the parameter to the spacebar press
        bool isPressed = Input.GetKey(KeyCode.Space);
        animator.SetBool("IsSquashed", isPressed);
    }
}
