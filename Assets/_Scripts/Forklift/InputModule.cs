using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    private IMovementModule _movementModule;

    private float _horizontal;
    private float _vertical;
    private bool _isBreaking;

    void Start()
    {
        _movementModule = GetComponent<MovementModule>();
    }

    
    void FixedUpdate()
    {
        GetInput();
        _movementModule.HandleMotor(_vertical, _isBreaking);
        _movementModule.HandleSteering(_horizontal);
        _movementModule.UpdateWheels();
    }

    private void GetInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _isBreaking = Input.GetKey(KeyCode.Space);
        Debug.Log(_isBreaking);
    }
}
