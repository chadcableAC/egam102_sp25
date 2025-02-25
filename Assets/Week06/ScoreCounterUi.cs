using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterUi : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        RefreshText();
    }

    public void AddToCount()
    {
        count++;
        RefreshText();
    }

    void RefreshText()
    {
        scoreText.text = $"{count}";
    }
}
