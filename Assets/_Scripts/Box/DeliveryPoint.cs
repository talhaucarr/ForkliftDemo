using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    [SerializeField] private GameObject delivery;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject == delivery)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
