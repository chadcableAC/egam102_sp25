using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUi : MonoBehaviour
{
    public GameObject enableHandle;

    void Start()
    {
        // Turn off
        enableHandle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Toggle the visibility when Q is pressed
            bool isActive = enableHandle.activeSelf;            
            enableHandle.SetActive(!isActive);
        }
    }

    public void ToggleMenu()
    {
        bool isActive = enableHandle.activeSelf;
        enableHandle.SetActive(!isActive);
    }

    public void LoadScene(string sceneName)
    {

    }
}
