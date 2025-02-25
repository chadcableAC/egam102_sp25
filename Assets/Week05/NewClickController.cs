using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClickController : MonoBehaviour
{
    public float circleCastRadius = 1f;

    void Update()
    {
        // First - reset all objects to normal
        NewClickableObject[] allObjects = FindObjectsOfType<NewClickableObject>();
        foreach (NewClickableObject clickable in allObjects)
        {
            clickable.Reset();
        }


        // Get the mouse position
        Vector2 mousePosition = Input.mousePosition;

        // Turn the screen position into a world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // What is overlapping with this position?
        Collider2D[] allColliders = Physics2D.OverlapCircleAll(worldPosition, circleCastRadius);
        foreach (Collider2D collider in allColliders)
        {
            // Does this collider have a script on it?
            NewClickableObject clickable = collider.transform.GetComponentInParent<NewClickableObject>();
            if (clickable != null)
            {
                clickable.OnHover();

                if (Input.GetMouseButtonDown(0))
                {
                    clickable.OnClick();
                }
            }
        }
    }
}
