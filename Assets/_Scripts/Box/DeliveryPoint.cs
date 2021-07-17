using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] private GameObject delivery;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == delivery)
        {
            Debug.Log("ha bu");
        }
    }
}
