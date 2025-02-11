using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    public Color defaultColor;
    public Color hoverColor;

    public void Reset()
    {
        myRenderer.color = defaultColor;
    }

    public void OnHover()
    {
        myRenderer.color = hoverColor;
    }

    public void OnClick()
    {
        Debug.Log(gameObject.name + " has been clicked!");
    }
}
