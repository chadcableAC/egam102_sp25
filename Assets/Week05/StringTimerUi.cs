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

        timerText.text = "Timer: " + Mathf.FloorToInt(timer) + "s";

        timerText1.text = string.Format("Timer: {0}s, {1:0.00}s", Mathf.FloorToInt(timer), timer);

        timerText2.text = $"Timer: {Mathf.FloorToInt(timer)}s, {timer:0.00}s";
    }
}
