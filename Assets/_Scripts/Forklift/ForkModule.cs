using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkModule : MonoBehaviour,IForkModule
{
    [Header("Requires")]
    [SerializeField] private Transform leftFork;
    [SerializeField] private Transform rightFork;

    [Header("Options")]
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float liftSpeed;

    private float temp;

    public void Lift(float vertical)
    {
        temp = vertical;
        leftFork.position += new Vector3(0f, vertical * liftSpeed * Time.deltaTime, 0f);
        rightFork.position += new Vector3(0f, vertical * liftSpeed * Time.deltaTime, 0f);

        if (leftFork.position.y > maxHeight)
        {
            leftFork.position = new Vector3(leftFork.position.x, maxHeight, leftFork.position.z);
            rightFork.position = new Vector3(rightFork.position.x, maxHeight, rightFork.position.z);
        }
        if (leftFork.position.y < minHeight)
        {
            leftFork.position = new Vector3(leftFork.position.x, minHeight, leftFork.position.z);
            rightFork.position = new Vector3(rightFork.position.x, minHeight, rightFork.position.z);
        }
    }

    public void PickUp()
    {
        throw new System.NotImplementedException();
    }

    public void PutDown()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Box))
        {
            Debug.Log(temp);
            collision.transform.position += new Vector3(0f, temp, 0f);
        }
    }
}
