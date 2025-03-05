using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerGuy : MonoBehaviour
{
    public GameObject leftObject;
    public GameObject rightObject;

    public bool isSewerLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        SetSide(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetSide(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetSide(false);
        }
    }

    public void SetSide(bool isLeft)
    {
        isSewerLeft = isLeft;

        leftObject.SetActive(false);
        rightObject.SetActive(false);

        if (isLeft)
        {
            leftObject.SetActive(true);
        }
        else
        {
            rightObject.SetActive(true);
        }

        //leftObject.SetActive(isLeft);
        //rightObject.SetActive(!isLeft);
    }
}
