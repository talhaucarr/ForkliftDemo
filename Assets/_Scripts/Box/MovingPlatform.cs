using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject palyer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            Debug.Log("here");
            palyer.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            Debug.Log("burda");
            palyer.transform.parent = null;
        }
    }
}
