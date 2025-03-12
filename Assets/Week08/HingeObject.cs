using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeObject : MonoBehaviour
{
    public HingeJoint2D hinge;
    public float motorSpeed = 100;

    void Update()
    {
        // On down - set the motor to positive
        if (Input.GetMouseButtonDown(0))
        {
            // Make a referecne to the motor
            JointMotor2D tempMotor = hinge.motor;

            // Change values on the reference
            tempMotor.motorSpeed = motorSpeed;

            // Then reassign the updated motor
            hinge.motor = tempMotor;
        }
        // On up - set the motor to negative
        else if (Input.GetMouseButtonUp(0))
        {
            // Make a referecne to the motor
            JointMotor2D tempMotor = hinge.motor;

            // Change values on the reference
            tempMotor.motorSpeed = -motorSpeed;

            // Then reassign the updated motor
            hinge.motor = tempMotor;
        }
    }
}
