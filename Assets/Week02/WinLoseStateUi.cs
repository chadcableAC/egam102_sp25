using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseStateUi : MonoBehaviour
{
    public GameObject winHandle;
    public GameObject loseHandle;
    public GameObject defaultGameHandle;

    public TextMeshProUGUI scoreText;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        winHandle.SetActive(false);
        loseHandle.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            score--;
            scoreText.text = "Score: " + score;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }

    // This is the version that works in one scene
    public void OnGameWin()
    {
        winHandle.SetActive(true);
        defaultGameHandle.SetActive(false);
    }

    public void OnGameLose()
    {
        loseHandle.SetActive(true);
        defaultGameHandle.SetActive(false);
    }

    // This is the version that works in seaparate scenes
    public void OnGameWinNewScene()
    {
        // Save to disk
        PlayerPrefs.SetInt("score", score);

        // Save to element in the scene
        ScoreSaveData saveData = FindObjectOfType<ScoreSaveData>();
        if (saveData != null)
        {
            saveData.score = score;
        }

        // Save to static
        ScoreSaveStatic.score = score;

        SceneManager.LoadScene("win_scene");
    }

    public void OnGameLoseNewScene()
    {
        SceneManager.LoadScene("lose_scene");
    }

    // Reload game button
    public void OnReload()
    {
        // This will load the active (current) scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnDeleteData()
    {
        PlayerPrefs.DeleteKey("score");

        //PlayerPrefs.DeleteAll();
    }
}
