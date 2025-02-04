using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaveData : MonoBehaviour
{
    public int score = 0;

    void Start()
    {
        // Let's get ALL of the ScoreSaveDatas in the scene
        ScoreSaveData[] allDatas = FindObjectsOfType<ScoreSaveData>();

        // If there's only one of us, stay around forever
        if (allDatas.Length <= 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
