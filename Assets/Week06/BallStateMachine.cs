using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStateMachine : MonoBehaviour
{
    public enum BallPosition
    {
        Pos01,  // 0
        Pos02,  // 1
        Pos03,  // 2
        Pos04,
        Pos05,
        Pos06,
        Pos07,
        Pos08,
        Pos09,
        Pos10
    }

    BallPosition currentPosition;

    public enum BallDirection
    {
        Left,
        Right,
        LeftEdge,
        RightEdge
    }

    BallDirection currentDirection;

    public List<GameObject> ballGameObjects;

    public float positionDuration = 0.8f;
    float positionTimer;

    public float edgeDuration = 0.5f;

    public BallPlayer.ArcPosition ballArcPosition;

    public bool isBallStartLeft;

    bool isPaused = false;

    bool isCaught = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial state based on left/right
        if (isBallStartLeft)
        {
            currentDirection = BallDirection.Right;
            SetPosition(BallPosition.Pos01);
        }
        else
        {
            currentDirection = BallDirection.Left;
            SetPosition(BallPosition.Pos10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only update when not paused
        if (isPaused == false)
        {
            // State machine updates
            switch (currentDirection)
            {
                case BallDirection.Left:
                    UpdateLeft();
                    break;
                case BallDirection.Right:
                    UpdateRight();
                    break;
                case BallDirection.LeftEdge:
                    UpdateLeftEdge();
                    break;
                case BallDirection.RightEdge:
                    UpdateRightEdge();
                    break;
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void UpdateLeft()
    {
        // Increase teh timer
        positionTimer += Time.deltaTime;

        // When we last the duration, move to the next position
        if (positionTimer >= positionDuration)
        {
            // Reset the timer
            positionTimer = 0;

            // See if the new position is the lowest one
            BallPosition newPosition = currentPosition - 1;
            if (newPosition == BallPosition.Pos01)
            {
                // If it is, switch directions
                SetDirection(BallDirection.LeftEdge);
            }

            // Finally apply the position
            SetPosition(newPosition);
        }
    }

    public void UpdateRight()
    {
        // Increase teh timer
        positionTimer += Time.deltaTime;

        // When we last the duration, move to the next position
        if (positionTimer >= positionDuration)
        {
            // Reset the timer
            positionTimer = 0;

            // See if the new position is the lowest one
            BallPosition newPosition = currentPosition + 1;
            if (newPosition == BallPosition.Pos10)
            {
                // If it is, switch directions
                SetDirection(BallDirection.RightEdge);
            }

            // Finally apply the position
            SetPosition(newPosition);
        }
    }

    public void UpdateLeftEdge()
    {
        // Increase teh timer
        positionTimer += Time.deltaTime;

        // Check every frame
        BallPlayer player = FindObjectOfType<BallPlayer>();
        if (player != null)
        {
            // Did we catch the ball?
            bool isBallCaught = player.CheckForBall(BallPlayer.ArcSide.Left, ballArcPosition);
            if (isBallCaught)
            {
                // Only update once (the first time we're setting
                // "isCaught" from false to true)
                if (isCaught == false)
                {
                    player.OnBallCaught();
                }
                isCaught = true;
            }
        }

        // When we last the duration, move to the next position
        if (positionTimer >= edgeDuration)
        {
            // Reset the timer
            positionTimer = 0;

            // Move onto the next state
            SetDirection(BallDirection.Right);
        }
    }


    public void UpdateRightEdge()
    {
        // Increase teh timer
        positionTimer += Time.deltaTime;

        // Check every frame
        BallPlayer player = FindObjectOfType<BallPlayer>();
        if (player != null)
        {
            // Did we catch the ball?
            bool isBallCaught = player.CheckForBall(BallPlayer.ArcSide.Left, ballArcPosition);
            if (isBallCaught)
            {
                // Only update once (the first time we're setting
                // "isCaught" from false to true)
                if (isCaught == false)
                {
                    player.OnBallCaught();
                }

                isCaught = true;
            }
        }

        // When we last the duration, move to the next position
        if (positionTimer >= edgeDuration)
        {
            // Reset the timer
            positionTimer = 0;

            // Move onto the next state
            SetDirection(BallDirection.Left);
        }
    }

    public void SetPosition(BallPosition newPosition)
    {
        // Set the position
        currentPosition = newPosition;

        // Turn the correct sprites on/off
        for (int i = 0; i < ballGameObjects.Count; i++)
        {
            bool isActiveBall = false;
            if (i == (int) currentPosition)
            {
                isActiveBall = true;
            }

            ballGameObjects[i].SetActive(isActiveBall);
        }
    }

    void SetDirection(BallDirection newDirection)
    {
        // Set the direction
        currentDirection = newDirection;

        switch (currentDirection)
        {            
            case BallDirection.LeftEdge:
            case BallDirection.RightEdge:
                // Start looking to see if the player caught us
                isCaught = false;
                break;

            case BallDirection.Left:
            case BallDirection.Right:
                // If this is false, the player didn't catch us in time
                if (isCaught == false)
                {
                    // Turn off the arc / ball
                    gameObject.SetActive(false);

                    // Tell the player we missed the ball
                    BallPlayer player = FindObjectOfType<BallPlayer>();
                    if (player != null)
                    {
                        BallPlayer.ArcSide failSide = BallPlayer.ArcSide.Left;
                        if (currentDirection == BallDirection.Left)
                        {
                            failSide = BallPlayer.ArcSide.Right;
                        }

                        player.EndGame(failSide);
                    }
                }
                break;
        }
    }
}
