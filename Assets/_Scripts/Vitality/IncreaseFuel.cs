using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFuel : MonoBehaviour
{
    [SerializeField] private float fuelTankAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            collision.gameObject.GetComponent<FuelModule>().IncreaseFuel(fuelTankAmount);
            Destroy(gameObject);
        }
    }
}
