using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            //TODO: game end.
            Destroy(collision.gameObject);
        }
    }
}
