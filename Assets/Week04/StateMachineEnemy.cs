using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineEnemy : MonoBehaviour
{
    public States state;

    // An enum gives ints a fancy, readable name
    public enum States
    {
        Idle,       // 0
        Chase,      // 1
        RunAway,    // 2
        Patrol      // 3
    }

    float stateTimer = 0;

    // How fast to move
    public float moveSpeed = 1;

    // The "player" object
    public Transform playerTransform;

    public SpriteRenderer myRenderer = null;

    public Color defaultColor;
    public Color idleColor;

    // Patrol variables
    public Transform[] patrolTransforms;
    public int patrolIndex;
    public float minimumPatrolPointDistance = 0.1f;
    public float minimumPatrolPlayerDistance = 2f;

    void Start()
    {
        // Make sure to set the starting state
        SetState(state);     
    }

    void Update()
    {
        // Increase the timer
        stateTimer += Time.deltaTime;

        // "Forward" the update to the current state
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
        // Set the state
        state = newState;

        // Reset the timer
        stateTimer = 0;

        // Update the color based on the new state
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
        // Get positions
        Vector3 targetPosition = playerTransform.position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPlayerDelta = targetPosition - ourPosition;
        Vector3 toPlayerDirection = toPlayerDelta.normalized;

        // Remember to use deltaTime when moving things in Update
        transform.position += toPlayerDirection * moveSpeed * Time.deltaTime;
    }

    private void UpdateRunAway()
    {
        // Get positions
        Vector3 targetPosition = playerTransform.position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPlayerDelta = targetPosition - ourPosition;
        Vector3 toPlayerDirection = toPlayerDelta.normalized;

        // Remember to use deltaTime when moving things in Update
        transform.position -= toPlayerDirection * moveSpeed * Time.deltaTime;

        // If we've been running away fro 5 seconds, take a break (go to idle)
        if (stateTimer >= 5)
        {
            SetState(States.Idle);
        }
    }

    private void UpdatePatrol()
    {
        // Get positions
        Vector3 targetPosition = patrolTransforms[patrolIndex].position;
        Vector3 ourPosition = transform.position;

        // The direction of A to B = B - A
        Vector3 toPatrolDelta = targetPosition - ourPosition;
        Vector3 toPatrolDirection = toPatrolDelta.normalized;

        // Remember to use deltaTime when moving things in Update
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
