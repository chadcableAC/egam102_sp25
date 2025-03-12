using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public SimplePlayer toFollow;

    public float followStrength = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 followPosition = toFollow.transform.position;

        Vector3 smoothingPosition = Vector3.Lerp(currentPosition, followPosition, Time.deltaTime * followStrength);

        // Preserve the camera's current depth (or z) position
        smoothingPosition.z = transform.position.z;

        // If the player is in air, don't update the y (so use the current position)
        if (toFollow.groundDetector.isGrounded == false)
        {
            smoothingPosition.y = currentPosition.y;
        }

        transform.position = smoothingPosition;
    }
}
