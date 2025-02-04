using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenUi : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreAlternateText;
    public TextMeshProUGUI scoreStaticText;

    // Start is called before the first frame update
    void Start()
    {
        // Show score via player prefs
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = "Final score: " + score;

        // Show score via DontDestroy
        int altScore = 0;
        ScoreSaveData saveData = FindObjectOfType<ScoreSaveData>();
        if (saveData != null)
        {
            altScore = saveData.score;
        }
        scoreAlternateText.text = "Save data score: " + altScore;

        // Show score via static class
        scoreStaticText.text = "Static score: " + ScoreSaveStatic.score;
    }
}
