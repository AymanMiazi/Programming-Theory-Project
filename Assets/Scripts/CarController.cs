using UnityEngine;
using System.Collections.Generic;
using TMPro;

public abstract class CarController : MonoBehaviour
{
    [SerializeField] private List<AxleInfo> axleInfos; // the information about each individual axle
    
    private float _maxMotorTorque = 600;
    protected float MaxMotorTorque
    {
        get => _maxMotorTorque;
        set
        {
            if (value > 0)
            {
                _maxMotorTorque = value;
            }
            else
            {
                Debug.LogError("Max Torque Cannot Be Negative");
            }
        }
    } // maximum torque the motor can apply to wheel

    private float _maxSteeringAngle = 60;
    protected float MaxSteeringAngle // maximum steer angle the wheel can have
    {
        get => _maxSteeringAngle;
        set
        {
            if (value > 0)
            {
                _maxSteeringAngle = value;
            }
            else
            {
                Debug.LogError("Max Steering Angle Cannot Be Negative");
            }
        }
    }

    private float _steering;
    private float _motor;

    private Rigidbody _playerRb;

    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private float speed;
    public CarTypes type;
    
    private void FixedUpdate()
    {
        _motor = MaxMotorTorque * Input.GetAxis("Vertical");
        _steering = MaxSteeringAngle * Input.GetAxis("Horizontal");
        WheelPhysics();
        DisplaySpeed();
        ResetPosition();
    }

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void WheelPhysics()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = _steering;
                axleInfo.rightWheel.steerAngle = _steering;
            }

            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = _motor;
                axleInfo.rightWheel.motorTorque = _motor;
            }
        }
    }

    private void DisplaySpeed()
    {
        speed = Mathf.Round(_playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + " km/h");
    }

    protected abstract void ActivateSpecial();

    private void ResetPosition()
    {
        if (transform.position.y < -10)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0,0,0);
            _playerRb.velocity = Vector3.zero;
        } 
    }
}


[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}