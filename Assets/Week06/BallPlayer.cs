using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayer : MonoBehaviour
{
    public Animator animator;

    int position = 0;


    public enum ArcSide
    {
        Left,
        Right        
    }

    public enum ArcPosition
    {
        Outer,
        Center,
        Inner
    }

    public GameObject leftCrushGameObject;
    public GameObject rightCrushGameObject;

    bool isPaused = false;

    private void Start()
    {
        // Turn off the game over values
        leftCrushGameObject.SetActive(false);
        rightCrushGameObject.SetActive(false);
    }

    void Update()
    {
        // Only update while not paused
        if (isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Subtract and clamp back into range
                position--;
                position = Mathf.Clamp(position, -1, 1);           
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Add and clamp back into range
                position++;
                position = Mathf.Clamp(position, -1, 1);
            }

            animator.SetInteger("Position", position);
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    // If this returns FALSE, that means the ball has been dropped
    public bool CheckForBall(ArcSide arcSide, ArcPosition arcPosition)
    {
        bool isBallCaught = false;

        // Determine whether the ball and hands are
        // at the same position
        switch (arcSide)
        {
            case ArcSide.Left:
                if (arcPosition == ArcPosition.Outer)
                {
                    if (position == -1)
                    {
                        isBallCaught = true;
                    }
                }
                else if (arcPosition == ArcPosition.Center)
                {
                    if (position == 0)
                    {
                        isBallCaught = true;
                    }
                }
                else if (arcPosition == ArcPosition.Inner)
                {
                    if (position == 1)
                    {
                        isBallCaught = true;
                    }
                }
                break;

            case ArcSide.Right:
                if (arcPosition == ArcPosition.Outer)
                {
                    if (position == 1)
                    {
                        isBallCaught = true;
                    }
                }
                else if (arcPosition == ArcPosition.Center)
                {
                    if (position == 0)
                    {
                        isBallCaught = true;
                    }
                }
                else if (arcPosition == ArcPosition.Inner)
                {
                    if (position == -1)
                    {
                        isBallCaught = true;
                    }
                }
                break;
        }

        return isBallCaught;
    }

    public void EndGame(ArcSide arcSide)
    {
        // Turn on the correct "fail" state
        switch (arcSide)
        {
            case ArcSide.Left:
                leftCrushGameObject.SetActive(true);
                break;

            case ArcSide.Right:
                rightCrushGameObject.SetActive(true);
                break;
        }

        // Tell the game flow the game is over
        GameFlowStateMachine gameFlow = FindObjectOfType<GameFlowStateMachine>();
        if (gameFlow != null)
        {
            gameFlow.SetState(GameFlowStateMachine.GameState.WinLose);
        }
    }

    public void OnBallCaught()
    {
        // Update the score
        ScoreCounterUi count = FindObjectOfType<ScoreCounterUi>();
        if (count != null)
        {
            count.AddToCount();
        }
    }
}
