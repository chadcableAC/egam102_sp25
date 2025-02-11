using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float circleCastRadius = 1f;

    void Update()
    {
        // First - reset all objects to normal
        ClickableObject[] allObjects = FindObjectsOfType<ClickableObject>();
        foreach (ClickableObject clickable in allObjects)
        {
            clickable.Reset();
        }


        // Get the mouse position
        Vector2 mousePosition = Input.mousePosition;

        // Turn the screen position into a world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // What is overlapping with this position?
        //Collider2D[] allColliders = Physics2D.OverlapPointAll(worldPosition);
        Collider2D[] allColliders = Physics2D.OverlapCircleAll(worldPosition, circleCastRadius);
        foreach (Collider2D collider in allColliders)
        {
            // Does this collider have a script on it?
            ClickableObject clickable = collider.transform.GetComponent<ClickableObject>();
            if (clickable != null)
            {
                clickable.OnHover();

                if (Input.GetMouseButtonDown(0))
                {
                    clickable.OnClick();
                }
            }
        }

        // Returns any collider it overlaps
        //Collider2D overlappingCollider = Physics2D.OverlapPoint(worldPosition);
        //if (overlappingCollider != null)
        //{
        //    // See if this game object has this script
        //    ClickableObject clickable = overlappingCollider.transform.GetComponent<ClickableObject>();
        //    if (clickable != null)
        //    {
        //        clickable.OnHover();

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            clickable.OnClick();
        //        }
        //    }
        //}

        //if (Physics2D.Raycast(worldPosition, Vector2.up))
        //{
        //    Debug.Log("Hit something!");
        //    debugRayColor = Color.red;
        //}
    }
}
