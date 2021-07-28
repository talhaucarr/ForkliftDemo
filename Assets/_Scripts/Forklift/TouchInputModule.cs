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
    [SerializeField] private Button gasButton;
    [SerializeField] private Button breakeButton;
    [SerializeField] private Button handbreakeButton;


    private IMovementModule _movementModule;
    private IForkModule _forkModule;
    private IFuelModule _fuelModule;

    private float _horizontal;
    private float _vertical;
    private bool _isBreaking;

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

    public void Handbreake()
    {
        _isBreaking = SwitchHanbreakeFlag();
    }

    public bool SwitchHanbreakeFlag()
    {
        _handbreakeFlag *= -1;
        if(_handbreakeFlag == 1) 
        {
            ColorBlock cb = handbreakeButton.colors;
            cb.normalColor = Color.green;
            cb.highlightedColor = new Color32(0, 243, 11, 255);
            cb.selectedColor = new Color32(0,243,11,255);
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

    private void MovementModuleHandler()
    {
        _movementModule.HandleSteering(_horizontal);
        _movementModule.UpdateWheels();
    }

    public void gasPedal()
    {
        Debug.Log("gas");
        _movementModule.HandleMotor(1.0f, _isBreaking);
        
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
}
