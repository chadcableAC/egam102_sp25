using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    public SpriteRenderer rendA;
    public SpriteRenderer rendB;

    public SpriteRenderer ourRenderer;

    public float lerpValue;

    void Update()
    {
        Color ourColor = Color.Lerp(rendA.color, rendB.color, lerpValue);
        ourRenderer.color = ourColor;

        Vector3 ourPos = Vector3.Lerp(rendA.transform.position, rendB.transform.position, lerpValue);
        ourRenderer.transform.position = ourPos;
    }
}
