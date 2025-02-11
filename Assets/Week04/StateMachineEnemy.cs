using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEnemy : MonoBehaviour
{
    public States state;

    public enum States
    {
        Idle,       // 0
        Chase,      // 1
        RunAway,    // 2
        Patrol      // 3
    }

    public float moveSpeed = 1;

    public Transform playerTransform;

    public SpriteRenderer myRenderer = null;

    public Color defaultColor;
    public Color idleColor;

    public Transform[] patrolTransforms;
    public int patrolIndex;
    public float minimumPatrolPointDistance = 0.1f;

    public float minimumPatrolPlayerDistance = 2f;

    float stateTimer = 0;

    void Start()
    {
        SetState(state);     
    }

    void Update()
    {
        stateTimer += Time.deltaTime;

        switch (state)
        {
            case States.Idle:
                UpdateIdle();
                break;

            case States.Chase:
                UpdateChase();
                break;

            case States.RunAway:
                UpdateRunAway();
                break;

            case States.Patrol:
                UpdatePatrol();
                break;
        }
    }

    void SetState(States newState)
    {
        state = newState;

        stateTimer = 0;

        myRenderer.color = defaultColor;
        switch (state)
        {
            case States.Idle:
                myRenderer.color = idleColor;
                break;
        }
    }

    private void UpdateIdle()
    {
        // If we've been idling for 5 seconds, switch to the patrol
        if (stateTimer >= 5)
        {
            SetState(States.Patrol);
        }
    }

    private void UpdateChase()
    {
        Vector3 targetPosition = playerTransform.position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPlayerDelta = targetPosition - ourPosition;
        Vector3 toPlayerDirection = toPlayerDelta.normalized;

        transform.position += toPlayerDirection * moveSpeed * Time.deltaTime;

        // If the player gets a powerup, switch to run away!

    }

    private void UpdateRunAway()
    {
        Vector3 targetPosition = playerTransform.position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPlayerDelta = targetPosition - ourPosition;
        Vector3 toPlayerDirection = toPlayerDelta.normalized;

        transform.position -= toPlayerDirection * moveSpeed * Time.deltaTime;

        // If we've been running away fro 5 seconds, take a break (go to idle)
        if (stateTimer >= 5)
        {
            SetState(States.Idle);
        }
    }

    private void UpdatePatrol()
    {
        Vector3 targetPosition = patrolTransforms[patrolIndex].position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPatrolDelta = targetPosition - ourPosition;
        Vector3 toPatrolDirection = toPatrolDelta.normalized;

        transform.position += toPatrolDirection * moveSpeed * Time.deltaTime;

        // Check to see if we're close enough to the goal
        float distanceToPatrolPoint = toPatrolDelta.magnitude;
        if (distanceToPatrolPoint < minimumPatrolPointDistance)
        {
            // Start following the next patrol point
            patrolIndex++;

            // Let's make sure we're in bounds on the list
            if (patrolIndex >= patrolTransforms.Length)
            {
                patrolIndex = 0;
            }
        }

        // See if we're close enough to the player
        Vector3 playerPosition = playerTransform.position;

        Vector3 toPlayerDelta = playerPosition - ourPosition;

        float distanceToPlayerPoint = toPlayerDelta.magnitude;
        if (distanceToPlayerPoint < minimumPatrolPlayerDistance)
        {
            SetState(States.Chase);            
        }
    }
}
