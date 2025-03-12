using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject sparkle;

    void Start()
    {
        // Start the apple without the sparkle, and frozen midair
        sparkle.SetActive(false);
        rb.simulated = false;
    }

    // Using "IEnumerator" means this is a coroutine
    public IEnumerator ExecuteFall()
    {
        // Turn on the sparkle
        sparkle.SetActive(true);

        // Wait for a second in realtime
        // The code will WAIT at this line until the time is completed
        yield return new WaitForSeconds(1f);

        // Turn the sparkle off
        sparkle.SetActive(false);

        // Let the apple fall
        rb.simulated = true;
    }
}
