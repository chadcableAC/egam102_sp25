using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUi : MonoBehaviour
{
    public void OnMenu()
    {
        // Find this script in the scene
        LevelSelectUi selectUi = FindObjectOfType<LevelSelectUi>();
        if (selectUi != null)
        {
            selectUi.ToggleMenu();
        }
    }
}
