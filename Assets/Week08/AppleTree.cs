using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    IEnumerator Start()
    {
        float delayTime = 2f;

        AppleObject[] apples = FindObjectsOfType<AppleObject>();
        foreach (AppleObject apple in apples)
        {
            yield return StartCoroutine(apple.ExecuteFall());

            //yield return new WaitForSeconds(delayTime);
            //delayTime *= 0.75f;

            yield return null;
        }
    }
}
