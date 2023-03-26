using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelScript : MonoBehaviour
{
    public bool isSpinning = false;

    public float rotationSpeed = 0f;
    public float minRotationSpeed = 10000000000000000000000000000000000000f;
    public float maxRotationSpeed = 100000000000000000000000000000000000000f;
    public float acceleration = 100000000000000000000000000000000000000f;//those fuckinhg values are fucking big and i dont care cuz only those work xddd
    public float deceleration = 100f;
    public float stopTime = 100000000000000000000000000000000000000f;
    public float minStopAngle = 15.0f;
    public float maxStopAngle = 345.0f;

    private float currentRotationSpeed = 0f;
    private float targetRotationSpeed = 100000000000000000000000000000000000000f;
    private float targetStopAngle = 0f;
    private float currentStopTime = 0f;

    private void Start()
    {
        isSpinning = false;//setting up variables
        currentRotationSpeed = rotationSpeed;//if not those wheel would spin i guess
    }

    private void Update()
    {
        if (isSpinning)
        {
            // Update rotation speed.
            if (currentRotationSpeed < targetRotationSpeed)
            {
                currentRotationSpeed += acceleration;//accelerate if rotation speed is lower than targeted one (targeted one is basicly max of how much wheel can spin)

            }
            else if (currentRotationSpeed > targetRotationSpeed)
            {
                currentRotationSpeed -= deceleration;//start deceleration if currentrotation speed is indeed highet than max
                if (currentRotationSpeed < targetRotationSpeed)
                {
                    currentRotationSpeed = targetRotationSpeed;// speed up if time is not up but wheel is not spining well
                }
            }

            // Update rotation angle.
            transform.Rotate(Vector3.back * currentRotationSpeed);

            // Check if we should stop spinning.
            if (currentStopTime > 0.0f)
            {
                currentStopTime -= Time.deltaTime;
                if (currentStopTime <= 0.0f)
                {
                    StopSpinning();
                }
                else
                {
                    // Check if we should start decelerating.
                    float currentAngle = transform.eulerAngles.z;
                    float deltaAngle = Mathf.DeltaAngle(currentAngle, targetStopAngle);
                    if (deltaAngle < minStopAngle || deltaAngle > maxStopAngle)
                    {
                        currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 10f, deceleration);
                    }
                }
            }
        }
    }

    public void spinwheel()//function that randomizes angles and speed for wheel
    {
        isSpinning = true;
        targetRotationSpeed = UnityEngine.Random.Range(minRotationSpeed, maxRotationSpeed);
        targetStopAngle = UnityEngine.Random.Range(0.0f, 360.0f);
        currentStopTime = stopTime;
    }

    public void StopSpinning()//this is some thing like hand brake for spinnin
    {
        isSpinning = false;
        currentStopTime = 0.0f;
        currentRotationSpeed = 0.0f;
    }
}
