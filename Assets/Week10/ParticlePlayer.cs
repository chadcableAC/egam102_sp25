using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public ParticleSystem fx;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fx.Play();
        }
        else if (Input.GetMouseButtonDown(1))
        {            
            fx.Stop();
            fx.Clear();
        }
        else if (Input.GetMouseButtonDown(2))
        {
            fx.Pause();
        }
    }
}
