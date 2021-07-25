using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputModule : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private float verticalLift;
    [SerializeField] private float fuelDecreaseAmount;

    private IMovementModule _movementModule;
    private IForkModule _forkModule;
    private IFuelModule _fuelModule;

    private float _horizontal;
    private float _vertical;
    private bool _isBreaking;

    void Start()
    {
        _movementModule = GetComponent<IMovementModule>();
        _forkModule = GetComponent<IForkModule>();
        _fuelModule = GetComponent<IFuelModule>();
    }
    void FixedUpdate()
    {
        GetMovementInput();
        GetLiftInput();
        FuelModuelHandler();
        MovementModuleHandler();
    }

    private void FuelModuelHandler()
    {
        if (_vertical != 0 || _horizontal != 0)
        {
            _fuelModule.DecreaseFuel(fuelDecreaseAmount);
        }
    }

    private void GetMovementInput()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void MovementModuleHandler()
    {
        _movementModule.HandleMotor(_vertical, _isBreaking);
        _movementModule.HandleSteering(_horizontal);
        _movementModule.UpdateWheels();
    }

    private void GetLiftInput()
    {
        if (Input.GetKey(KeyCode.J)) { Debug.Log("saJ"); ForkModuleHandler(verticalLift); return; }//Up
        if (Input.GetKey(KeyCode.K)) { Debug.Log("saK"); ForkModuleHandler(-verticalLift); return; }//Down
        ForkModuleHandler(0.0f);
    }

    private void ForkModuleHandler(float verticalDir)
    {
        _forkModule.Lift(verticalDir);
    }

}
