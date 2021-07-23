using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject palyer;
    public bool test = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            palyer.transform.SetParent(gameObject.transform, true);

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
