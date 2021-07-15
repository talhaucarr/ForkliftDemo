using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSPeed;

    [SerializeField] public enum CameraMods { SideView, TopView, RearView}
    [SerializeField] public CameraMods CurMode = CameraMods.RearView;

    private void FixedUpdate()
    {
        CameraInput();
        CameraTranslation();
        CameraRotation();
    }

    private void CameraInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { CurMode = CameraMods.RearView; }//input module koyamadim??
        if (Input.GetKeyDown(KeyCode.Alpha2)) { CurMode = CameraMods.SideView; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { CurMode = CameraMods.TopView; }
        SwitchCameraMode();
    }

    private void CameraTranslation()
    {
        Vector3 targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    private void CameraRotation()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSPeed * Time.deltaTime);
    }

    public void SwitchCameraMode()
    {
        switch (CurMode)
        {
            case CameraMods.SideView:
                offset = new Vector3(-20, 10, 0);
                break;
            case CameraMods.TopView:
                offset = new Vector3(5, 30, 1);
                break;
            case CameraMods.RearView:
                offset = new Vector3(0, 15, -25);
                break;
            default:
                break;
        }
    }
}
