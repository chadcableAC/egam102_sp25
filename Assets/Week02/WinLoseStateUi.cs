using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseStateUi : MonoBehaviour
{
    public GameObject winHandle;
    public GameObject loseHandle;
    public GameObject defaultGameHandle;


    // Start is called before the first frame update
    void Start()
    {
        winHandle.SetActive(false);
        loseHandle.SetActive(false);
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
}
