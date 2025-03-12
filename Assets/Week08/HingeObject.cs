using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeObject : MonoBehaviour
{
    public HingeJoint2D hinge;

    public float motorSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Make a referecne to the motor
            JointMotor2D tempMotor = hinge.motor;

            // Change values on the reference
            tempMotor.motorSpeed = motorSpeed;

            // Then reassign the updated motor
            hinge.motor = tempMotor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            JointMotor2D tempMotor = hinge.motor;
            tempMotor.motorSpeed = -motorSpeed;
            hinge.motor = tempMotor;
        }
    }
}
