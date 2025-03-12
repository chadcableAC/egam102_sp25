using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleObject : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject sparkle;

    bool isFallen = false;

    Coroutine fallRoutine;

    // Start is called before the first frame update
    void Start()
    {
        sparkle.SetActive(false);
        rb.simulated = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fallRoutine = StartCoroutine(ExecuteFall());
        }

        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();

            //if (fallRoutine != null)
            //{
            //    StopCoroutine(fallRoutine);
            //}
        }
    }

    public IEnumerator ExecuteFall()
    {
        sparkle.SetActive(true);

        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                break;
            }

            yield return null;
        }

        sparkle.SetActive(false);
        rb.simulated = true;
    }
}
