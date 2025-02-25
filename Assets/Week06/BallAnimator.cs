using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimator : MonoBehaviour
{
    public Animator animator;

    public float playbackFactor = 1f;

    public BallPlayer.ArcPosition ballArcPosition;

    public bool isBallStartLeft;

    bool isPaused = false;

    public enum BallState
    {
        CheckingLeft,        
        CheckingRight,
        IsCaught,
        InAir
    }

    public BallState currentState;

    void Start()
    {
        // Default to in air
        currentState = BallState.InAir;

        // Set parameters to update the animator
        if (isBallStartLeft)
        {
            animator.SetTrigger("IsStartLeft");
        }
        else
        {
            animator.SetTrigger("IsStartRight");
        }
    }

    void Update()
    {
        // Paused? Stop the animator
        if (isPaused)
        {
            animator.speed = 0;
        }
        // Otherwise update the animator
        else
        {
            animator.speed = playbackFactor;

            switch (currentState)
            {
                case BallState.CheckingLeft:
                case BallState.CheckingRight:
                    UpdateBallCheck();
                    break;
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void UpdateBallCheck()
    {
        // First get the player
        BallPlayer player = FindObjectOfType<BallPlayer>();
        if (player != null)
        {
            // Determine which side we're on
            BallPlayer.ArcSide side = BallPlayer.ArcSide.Right;
            if (currentState == BallState.CheckingLeft)
            {
                side = BallPlayer.ArcSide.Left;
            }

            // See if we've caught the ball
            bool isBallCaught = player.CheckForBall(side, ballArcPosition);
            if (isBallCaught)
            {
                // Switch states
                currentState = BallState.IsCaught;

                // Tell the player we've been caught
                player.OnBallCaught();
            }
        }
    }

    public void StartCheckLeft()
    {
        // Switch state
        currentState = BallState.CheckingLeft;
    }

    public void StartCheckRight()
    {
        // Switch state
        currentState = BallState.CheckingRight;
    }

    public void EndCheck()
    {
        // If our state is NOT IsCaught, the player
        // didn't catch us in time
        if (currentState != BallState.IsCaught)
        {
            // Turn off the whole arc / ball
            gameObject.SetActive(false);

            // Tell the player we missed
            BallPlayer player = FindObjectOfType<BallPlayer>();
            if (player != null)
            {
                switch (currentState)
                {
                    case BallState.CheckingLeft:
                        player.EndGame(BallPlayer.ArcSide.Left);
                        break;
                    case BallState.CheckingRight:
                        player.EndGame(BallPlayer.ArcSide.Right);
                        break;
                }
            }
        }
    }
}
