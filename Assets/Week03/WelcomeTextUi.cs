using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WelcomeTextUi : MonoBehaviour
{
    public List<string> welcomeStrings;
    public TextMeshProUGUI welcomeText;

    void Start()
    {
        ChooseWelcomeText();
    }

    public void ChooseWelcomeText()
    {
        // Pick a random string to show
        int randomIndex = Random.Range(0, welcomeStrings.Count);
        string randomString = welcomeStrings[randomIndex];
        welcomeText.text = randomString;
    }
}
