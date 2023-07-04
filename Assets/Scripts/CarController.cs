using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public abstract class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    
    private float m_maxMotorTorque = 600;
    public float maxMotorTorque
    {
        get { return m_maxMotorTorque; }
        set
        {
            if (value > 0)
            {
                m_maxMotorTorque = value;
            }
            else
            {
                Debug.LogError("Max Torque Cannot Be Negative");
            }
        }
    } // maximum torque the motor can apply to wheel

    private float m_maxSteeringAngle = 60;
    public float maxSteeringAngle // maximum steer angle the wheel can have
    {
        get { return m_maxSteeringAngle; }
        set
        {
            if (value > 0)
            {
                m_maxSteeringAngle = value;
            }
            else
            {
                Debug.LogError("Max Steering Angle Cannot Be Negative");
            }
        }
    }

    private float steering;
    private float motor;

    private Rigidbody playerRb;
    
    [SerializeField] private MainManager.CarTypes type;
    
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private float speed;
    
    private void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        WheelPhysics();
        DisplaySpeed();
    }

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void WheelPhysics()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }

    private void DisplaySpeed()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + " km/h");
    }

    protected abstract void ActivateSpecial();
}


[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}