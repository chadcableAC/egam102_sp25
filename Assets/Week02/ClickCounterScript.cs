using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickCounterScript : MonoBehaviour
{

    public int counter = 0;

    public TextMeshProUGUI counterText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool wasClicked = false;

        // On left click, add 1
        if (Input.GetMouseButtonDown(0))
        {
            //counter = counter + 1;
            counter += 1;        

            wasClicked = true;

            counterText.text = "Clicks: " + counter;
        }

        // On right click, subtract 1
        if (Input.GetMouseButtonDown(1))
        {
            //counter = counter - 1;
            counter -= 1;

            wasClicked = true;

            counterText.text = "Clicks: " + counter;
        }

        if (wasClicked)
        {
            // Add a little message based on the count number
            if (counter == 0)
            {
                counterText.text = counterText.text + " (No clicks!)";
            }
            else if (counter < 0)
            {
                counterText.text = counterText.text + " (Oh no, we're negative)";
            }
            else if (counter > 0)
            {
                counterText.text = counterText.text + " (Yeaaaaah positive!)";

                if (counter >= 10)
                {
                    counterText.text = counterText.text + ", by over 10!!";
                }
                else if (counter >= 5)
                {
                    counterText.text = counterText.text + ", by over 5!";
                }
            }
        }
    }
}
