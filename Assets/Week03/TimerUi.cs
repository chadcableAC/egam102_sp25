using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUi : MonoBehaviour
{
    public Image fillImage;

    public float duration = 1f;
    float timer;

    public TextMeshProUGUI text;

    void Update()
    {
        timer += Time.deltaTime;

        // We have to turn the timer into a value between 0 and 1
        float timerInterp = timer / duration;
        fillImage.fillAmount = 1f - timerInterp;
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
