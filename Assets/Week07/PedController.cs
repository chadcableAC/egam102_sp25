using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedController : MonoBehaviour
{
    public Animator animator;
    public float playback_speed = 1f;

    public bool isHeld = false;
    public bool isDecisionTime = false;
    public bool isLeftSide = false;

    // Start is called before the first frame update
    void Start()
    {
        animator.speed = playback_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDecisionTime)
        {
            SewerGuy sewer = FindObjectOfType<SewerGuy>();
            if (sewer != null)
            {
                // Are we on matching sides?
                if (sewer.isSewerLeft && isLeftSide)
                {
                    isHeld = true;
                }
                else if (!sewer.isSewerLeft && !isLeftSide)
                {
                    isHeld = true;
                }
            }
        }
    }

    public void StartDecisionLeft()
    {
        isDecisionTime = true;
        isHeld = false;
        isLeftSide = true;
    }

    public void StartDecisionRight()
    {
        isDecisionTime = true;
        isHeld = false;
        isLeftSide = false;
    }

    public void EndDecision()
    {
        isDecisionTime = false;

        // No one held us - we must have fallen
        if (isHeld == false)
        {
            animator.SetBool("IsHeld", false);
        }
        // We were caught! Update the parameter
        else
        {
            animator.SetBool("IsHeld", true);
        }
    }
}
