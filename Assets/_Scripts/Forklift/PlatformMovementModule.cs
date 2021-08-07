using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementModule : MonoBehaviour
{
    [SerializeField] private Transform centerOfMass;
    
    private Vector3 _lastPlatformPosition;
    private MovingPlatform _curPlatform;
    private Rigidbody _rb;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_curPlatform) { return; }

        _rb.velocity += (_curPlatform.transform.position - _lastPlatformPosition);
        _lastPlatformPosition = _curPlatform.transform.position;
    }

    public void EnteredPlatform(MovingPlatform platform)
    {
        Debug.Log($"EnteredPaltform: {platform}", platform.gameObject);
        _curPlatform = platform;
        _lastPlatformPosition = platform.transform.position;
    }

    public void LeftPlatform(MovingPlatform platform)
    {
        Debug.Log($"LeftPaltform: {platform}", platform.gameObject);
        if (platform == _curPlatform) _curPlatform = null;
    }
}
