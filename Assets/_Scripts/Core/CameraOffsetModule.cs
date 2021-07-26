using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOffsetModule : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cvm;

    [SerializeField] public enum CameraMods { SideView, TopView, RearView }
    [SerializeField] public CameraMods CurMode = CameraMods.RearView;

    private CinemachineTransposer _cinemachineTransposer;

    private void Start()
    {
        _cinemachineTransposer = cvm.GetCinemachineComponent<CinemachineTransposer>();        
    }

    private void LateUpdate()
    {
        SwitchCameraMode();
    }

    public void CameraSideView()
    {
        CurMode = CameraMods.SideView;
    }
    public void CameraRearView()
    {
        CurMode = CameraMods.RearView;
    }
    public void CameraTopView()
    {
        CurMode = CameraMods.TopView;
    }

    public void SwitchCameraMode()
    {
        switch (CurMode)
        {
            case CameraMods.SideView:
                _cinemachineTransposer.m_FollowOffset = new Vector3(-10, 5, 0);
                break;
            case CameraMods.TopView:
                _cinemachineTransposer.m_FollowOffset = new Vector3(0, 10, -1);
                break;
            case CameraMods.RearView:
                _cinemachineTransposer.m_FollowOffset = new Vector3(0, 8, -10);
                break;
            default:
                break;
        }
    }
}
