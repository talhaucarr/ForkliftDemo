using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour, IMovementModule
{
    [Header("Options")]
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    [Header("Transform Requires")]
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform rearLeftTransform;
    [SerializeField] private Transform rearRightTransform;

    [Header("Collider Requires")]
    [SerializeField] private WheelCollider frontLeftlCollider;
    [SerializeField] private WheelCollider frontRightlCollider;
    [SerializeField] private WheelCollider rearLeftlCollider;
    [SerializeField] private WheelCollider rearRightlCollider;

    private float _currentSteerAngle;
    private float _currentBreakForce;

    public void HandleSteering(float horizontalInput)
    {
        _currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftlCollider.steerAngle = _currentSteerAngle;
        frontRightlCollider.steerAngle = _currentSteerAngle;
    }

    public void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftlCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightlCollider, frontRightTransform);
        UpdateSingleWheel(rearLeftlCollider, rearLeftTransform);
        UpdateSingleWheel(rearRightlCollider, rearRightTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.SetPositionAndRotation(pos, rot);
    }

    public void HandleMotor(float verticalInput, bool isBreaking)
    {
        frontLeftlCollider.motorTorque = verticalInput * motorForce;
        
        frontRightlCollider.motorTorque = verticalInput * motorForce;
        _currentBreakForce = isBreaking ? breakForce : 0f;       
        ApplyBreaking();
      
    }

    private void ApplyBreaking()
    {
        frontRightlCollider.brakeTorque = _currentBreakForce;
        frontLeftlCollider.brakeTorque = _currentBreakForce;
        rearLeftlCollider.brakeTorque = _currentBreakForce;
        rearRightlCollider.brakeTorque = _currentBreakForce;
    }
}
