using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInputSprite : MonoBehaviour
{
    public SpriteRenderer spriteVisual;

    public Color downColor;
    public Color upColor;

    public Color downColorKey;

    public Sprite spriteMouse;
    public Sprite spriteKey;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This is listening for the left mouse up and down
        if (Input.GetMouseButtonDown(0) == true)
        {
            Debug.Log("Mouse is down!");

            spriteVisual.color = downColor;
            spriteVisual.sprite = spriteMouse;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse is up!");

            spriteVisual.color = upColor;
        }

        // This is listening for the Spacebar up and down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteVisual.color = downColorKey;
            spriteVisual.sprite = spriteKey;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            spriteVisual.color = upColor;
        }
    }
}
