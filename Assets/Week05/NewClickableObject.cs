using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClickableObject : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    public Color defaultColor;
    public Color hoverColor;

    public void Reset()
    {
        // Return to the default color
        myRenderer.color = defaultColor;
    }

    public void OnHover()
    {
        // Set to the hover color
        myRenderer.color = hoverColor;
    }

    public void OnClick()
    {
        Debug.Log(gameObject.name + " has been clicked!");
    }
}
