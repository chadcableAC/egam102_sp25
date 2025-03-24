using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObject : MonoBehaviour
{
    public Transform handleA;
    public Transform handleB;

    public float lerpValue;

    public float lerpDuration = 1;
    public float lerpTimer = 0;

    public bool isAnimated = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isAnimated)
        {
            lerpTimer += Time.deltaTime;
            float interp = lerpTimer / lerpDuration;

            transform.position = Vector3.Lerp(handleA.position, handleB.position, interp);
        }
        else
        {
            transform.position = Vector3.LerpUnclamped(handleA.position, handleB.position, lerpValue);
        }
    }
}
