using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    [SerializeField] private float verticalLift;

    private IMovementModule _movementModule;
    private IForkModule _forkModule;

    private float _horizontal;
    private float _vertical;
    private bool _isBreaking;

    void Start()
    {
        _movementModule = GetComponent<MovementModule>();
        _forkModule = GetComponent<ForkModule>();
    }

    
    void FixedUpdate()
    {
        GetMovementInput();
        GetLiftInput();
        MovementModuleHandler();
    }
    private void GetMovementInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _isBreaking = Input.GetKey(KeyCode.Space);
        Debug.Log(_isBreaking);
    }
    private void MovementModuleHandler()
    {
        _movementModule.HandleMotor(_vertical, _isBreaking);
        _movementModule.HandleSteering(_horizontal);
        _movementModule.UpdateWheels();
    }

    private void GetLiftInput()
    {
        if (Input.GetKey(KeyCode.J)) { ForkModuleHandler(verticalLift);  return; }
        if (Input.GetKey(KeyCode.K)) { ForkModuleHandler(-verticalLift); return; }
        ForkModuleHandler(0.0f);
    }

    private void ForkModuleHandler(float verticalDir)
    {
        _forkModule.Lift(verticalDir);
    }
}
