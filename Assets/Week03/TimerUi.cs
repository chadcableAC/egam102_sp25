using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUi : MonoBehaviour
{
    // The clock image to fill
    public Image fillImage;

    // How long the timer lasts
    public float duration = 1f;
    float timer;

    void Update()
    {
        // Add to the timer
        timer += Time.deltaTime;

        // We have to turn the timer into a value between 0 and 1
        float timerInterp = timer / duration;
        fillImage.fillAmount = timerInterp;
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
