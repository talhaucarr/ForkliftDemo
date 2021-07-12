using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour, IMovementModule
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float turningPointDistance;

    private Rigidbody _rb;

    private Vector3 _turningPoint;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CalculateTurningPoint();
    }

    private void CalculateTurningPoint()
    {
        _turningPoint =  -transform.position - transform.right * turningPointDistance * -1;
    }

    public void Move(Vector3 dir)
    {
        transform.RotateAround(_turningPoint, Vector3.up, turnSpeed * Time.deltaTime * dir.x / turningPointDistance);
        _rb.MovePosition(transform.position + Time.deltaTime * speed * dir);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(_turningPoint + Vector3.up, 0.3f);
    }
}
