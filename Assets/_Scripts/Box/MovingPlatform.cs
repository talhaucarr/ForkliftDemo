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
            //int childct;
            ////palyer.transform.SetParent(gameObject.transform, true);

            //childct = palyer.transform.childCount;
            //for (int i = 0; i < childct; i++)
            //{
            //    palyer.transform.GetChild(i).parent = palyer.transform;
            //}
            //palyer.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        //{
        //    Debug.Log("burda");
        //    palyer.transform.parent = null;
        //}
    }
}
