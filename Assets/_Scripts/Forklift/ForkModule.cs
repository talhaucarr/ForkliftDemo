using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkModule : MonoBehaviour,IForkModule
{
    [Header("Requires")]
    [SerializeField] private Transform forkLift;

    [Header("Options")]
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float liftSpeed;

    private float temp;

    public void Lift(float vertical)
    {
        temp = vertical;
       
        forkLift.localPosition += new Vector3(0f, vertical * liftSpeed * Time.deltaTime, 0f);

        if (forkLift.localPosition.y > maxHeight)
        {
            forkLift.localPosition = new Vector3(forkLift.localPosition.x, maxHeight, forkLift.localPosition.z);
        }
        if (forkLift.localPosition.y < minHeight)
        {
            forkLift.localPosition = new Vector3(forkLift.localPosition.x, minHeight, forkLift.localPosition.z);
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
            collision.transform.position += new Vector3(0f, temp, 0f);
        }
    }
}
