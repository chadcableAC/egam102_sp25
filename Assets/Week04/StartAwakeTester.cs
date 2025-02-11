using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAwakeTester : MonoBehaviour
{
    // Only called ONCE
    // Awake is called first
    void Awake()
    {

    }

    // Only called ONCE
    // Start is called second (so after awake)
    void Start()
    {
        FunctionOne();
        FunctionTwo();
    }

    void FunctionOne()
    {

    }

    void FunctionTwo()
    {
        // I need function one to run first!

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
