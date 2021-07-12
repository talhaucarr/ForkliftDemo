using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputModule : MonoBehaviour
{
    private IMovementModule _movementModule;
    private float _horizontal;
    private float _vertical;
    private Vector3 _dir;

    void Start()
    {
        _movementModule = GetComponent<MovementModule>();
    }

    
    void Update()
    {
        GetMoveDir();
        Debug.Log(_dir);
        _movementModule.Move(_dir);
    }

    private void GetMoveDir()
    {      
        _dir = Vector3.zero;

        _dir.z = -1 * Input.GetAxisRaw("Horizontal");
        _dir.x = -1 * Input.GetAxisRaw("Vertical");

        _dir.Normalize();
    }
}
