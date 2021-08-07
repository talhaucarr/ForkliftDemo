using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private APointProvider pointProvider;
    [SerializeField] private float platformSpeed;

    private int _curPointIndex = 0;
    private List<Transform> _points;
    private Rigidbody _rb;

    public Vector3 test;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _points = pointProvider.GetPointList();
    }
    private void Update()
    {
        CheckTargetReached();
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        _rb.velocity = platformSpeed * Time.deltaTime * (_points[_curPointIndex].position - transform.position).normalized;
        test = _rb.velocity;
    }

    private void CheckTargetReached()
    {
        if (Vector3.Distance(transform.position, _points[_curPointIndex].position) < 0.01f)
        {
            _curPointIndex++;
            if (_curPointIndex == _points.Count) _curPointIndex = 0;
        }
    }
}
