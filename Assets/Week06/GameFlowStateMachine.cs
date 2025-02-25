using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowStateMachine : MonoBehaviour
{
    public enum GameState
    {
        Intro,
        Gameplay,
        WinLose
    }

    public GameState currentState;

    void Start()
    {
        SetState(GameState.Intro);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            // Tell all of the necessary scripts the game has ended
            case GameState.WinLose:
                BallAnimator[] ballAnims = FindObjectsOfType<BallAnimator>();
                foreach (BallAnimator ballAnim in ballAnims)
                {
                    ballAnim.Pause();
                }

                BallStateMachine[] ballMachines = FindObjectsOfType<BallStateMachine>();
                foreach (BallStateMachine ballMachine in ballMachines)
                {
                    ballMachine.Pause();
                }

                BallPlayer ballPlayer = FindObjectOfType<BallPlayer>();
                if (ballPlayer != null)
                {
                    ballPlayer.Pause();
                }

                break;
        }
    }
}
