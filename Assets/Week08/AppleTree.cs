using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Using "IEnumerator" means this is a coroutine
    // We can turn ANY Start() into a coroutine
    IEnumerator Start()
    {
        // Find all of the apples
        AppleObject[] apples = FindObjectsOfType<AppleObject>();
        foreach (AppleObject apple in apples)
        {
            // Tell the apple to fall
            // Remember this function on apple is a coroutine,
            // so we need to wrap the function in StartCoroutine()
            StartCoroutine(apple.ExecuteFall());

            // Wait 2 seconds before dropping the next apple
            yield return new WaitForSeconds(2f);
        }
    }
}
