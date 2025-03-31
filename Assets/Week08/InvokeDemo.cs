using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeDemo : MonoBehaviour
{
    public SpriteRenderer renderer;

    public Color reset;
    public Color instant;
    public Color delay;

    public float delayInSeconds = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            renderer.color = instant;
            //ChangeColor();

            Invoke("ChangeColor", delayInSeconds);
        }

        if (Input.GetMouseButtonDown(2))
        {
            StartCoroutine(ExecuteColorSwaps());
        }

        if (Input.GetMouseButtonDown(1))
        {
            renderer.color = reset;
        }
    }

    // An invoke delays the START of the function
    void ChangeColor()
    {
        renderer.color = delay;
    }

    // A coroutine can delay INSIDE of the function
    IEnumerator ExecuteColorSwaps()
    {
        renderer.color = delay;
        yield return new WaitForSeconds(1f);
        renderer.color = instant;
        yield return new WaitForSeconds(1f);
        renderer.color = delay;
        yield return new WaitForSeconds(1f);
        renderer.color = instant;
        yield return new WaitForSeconds(1f);
        renderer.color = delay;
    }
}
