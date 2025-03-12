using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolObject : MonoBehaviour
{
    public GroundScript ground;

    public SpriteRenderer rend;


    // Start is called before the first frame update
    void Start()
    {
        ground = FindObjectOfType<GroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
