using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StringTimerUi : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText1;
    public TextMeshProUGUI timerText2;

    public float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 60;
        }

        // We can "add" strings and variables together
        // To make a long string
        timerText.text = "Timer: " + Mathf.FloorToInt(timer) + "s";

        // Each numbered bracket is linked to a variable
        // {0} is the first variable, {1} is the second, etc
        timerText1.text = string.Format("Timer: {0}s, {1:0.00}s", Mathf.FloorToInt(timer), timer);

        // The $ sign in front will replace values inside
        // brackets with the variable
        timerText2.text = $"Timer: {Mathf.FloorToInt(timer)}s, {timer:0.00}s";
    }
}
