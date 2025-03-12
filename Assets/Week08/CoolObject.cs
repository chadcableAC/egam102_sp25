using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolObject : MonoBehaviour
{
    // This reference is on our prefab
    public SpriteRenderer rend;

    // This reference is OUTSIDE our prefab,
    // so we'll need to relink it
    public GroundScript ground;

    void Start()
    {
        // Find a reference to the ground,
        // since we might not have it
        ground = FindObjectOfType<GroundScript>();
    }
}
