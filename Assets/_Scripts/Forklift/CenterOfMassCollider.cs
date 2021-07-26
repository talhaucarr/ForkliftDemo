using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassCollider : MonoBehaviour
{
    [SerializeField] private PlatformMovementModule _pmm;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.MovingPlatform))
        {
            _pmm.EnteredPlatform(other.GetComponent<MovingPlatform>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.MovingPlatform))
        {
            _pmm.LeftPlatform(other.GetComponent<MovingPlatform>());
        }
    }
}
