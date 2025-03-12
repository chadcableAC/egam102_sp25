using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Object to follow
    public SimplePlayer toFollow;

    // How strong should the follow be
    // Higher numbers will follow more closely
    // Lower numbers will follow more loosely
    public float followStrength = 1f;

    void Update()
    {
        // Get the positions
        Vector3 currentPosition = transform.position;
        Vector3 followPosition = toFollow.transform.position;

        // Use a lerp to find a poisition inbetween these two
        // We know Time.deltaTime is a small number,
        // so we'll find a position closer to the current position
        Vector3 smoothingPosition = Vector3.Lerp(currentPosition, followPosition, Time.deltaTime * followStrength);

        // Preserve the camera's current depth (or z) position
        smoothingPosition.z = transform.position.z;

        // If the player is in air, don't update the y (so use the current position)
        if (toFollow.groundDetector.isGrounded == false)
        {
            smoothingPosition.y = currentPosition.y;
        }

        // Finally update our position
        transform.position = smoothingPosition;
    }
}
