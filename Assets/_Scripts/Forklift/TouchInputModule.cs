using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchInputModule : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick liftJoystick;
    [SerializeField] private float verticalLift;
    [SerializeField] private float fuelDecreaseAmount;
    [SerializeField] private Button handbreakeButton;
    [SerializeField] private float breakeForce;


    private IMovementModule _movementModule;
    private IForkModule _forkModule;
    private IFuelModule _fuelModule;

    private float _horizontal;
    private float _vertical;
    private bool _isHandbreake;

    private bool _isGas = false;
    private bool _isBreake = false;

    private float _handbreakeFlag = -1; //-1 Off - 1 On
   

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
        if (_isGas) { GasPedal(1.0f); return; }
        if(_isBreake) { BreakePedal(breakeForce); return; }
        else { GasPedal(.0f); }
        
    }

    private void GasPedal(float torque)
    {
        _movementModule.HandleMotor(torque, _isHandbreake);
    }
    private void BreakePedal(float breakeForce)
    {
        _movementModule.HandleBreake(breakeForce);
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
        _horizontal = moveJoystick.Horizontal;
        _vertical = moveJoystick.Vertical;
    }

    private void MovementModuleHandler()
    {
        
        _movementModule.HandleSteering(_horizontal);
        _movementModule.UpdateWheels();
    }

    private void GetLiftInput()
    {
        if (liftJoystick.Vertical >= .2f) { ForkModuleHandler(verticalLift); return; }//Up
        if (liftJoystick.Vertical <= -.2f) { ForkModuleHandler(-verticalLift); return; }//Down
        ForkModuleHandler(0.0f);
    }

    private void ForkModuleHandler(float verticalDir)
    {
        _forkModule.Lift(verticalDir);
    }
    public void GasButtonUp()
    {
        _isGas = false;
    }
    public void GasButtonDown()
    {
        _isGas = true;
    }
    public void BreakeButtonUp()
    {     
        _isBreake = false;
    }
    public void BreakeButtonDown()
    {
        _isBreake = true;
    }

    public void Handbreake()
    {
        _isHandbreake = SwitchHanbreakeFlag();
    }

    public bool SwitchHanbreakeFlag()
    {
        _handbreakeFlag *= -1;
        if (_handbreakeFlag == 1)
        {
            ColorBlock cb = handbreakeButton.colors;
            cb.normalColor = Color.green;
            cb.highlightedColor = new Color32(0, 243, 11, 255);
            cb.selectedColor = new Color32(0, 243, 11, 255);
            handbreakeButton.colors = cb;
            return true;
        }
        else
        {
            ColorBlock cb = handbreakeButton.colors;
            cb.normalColor = Color.red;
            cb.highlightedColor = new Color32(255, 0, 0, 255);
            cb.selectedColor = new Color32(255, 0, 0, 255);
            handbreakeButton.colors = cb;

            return false;
        }
    }
}
