using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraOffsetModule : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera sideView;
    [SerializeField] private CinemachineVirtualCamera rearView;
    [SerializeField] private CinemachineVirtualCamera topView;
    [SerializeField] private CinemachineVirtualCamera domView;

    private void Start()
    {
        sideView.enabled = false;
        rearView.enabled = true;
        topView.enabled = false;
        domView.enabled = false;
    }

    public void CameraSideView()
    {
        sideView.enabled = true;
        rearView.enabled = false;
        topView.enabled = false;
        domView.enabled = false;
    }
    public void CameraRearView()
    {
        sideView.enabled = false;
        rearView.enabled = true;
        topView.enabled = false;
        domView.enabled = false;
    }
    public void CameraTopView()
    {
        sideView.enabled = false;
        rearView.enabled = false;
        topView.enabled = true;
        domView.enabled = false;
    }
    public void DominicTorettoView()
    {
        sideView.enabled = false;
        rearView.enabled = false;
        topView.enabled = false;
        domView.enabled = true;
    }
}
