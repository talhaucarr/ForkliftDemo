using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public enum MovingMods { UpDown, RightLeft, ForthBack };

    [SerializeField] private float movingDir;
    [SerializeField] private float movingSpeed;

    [SerializeField] private MovingMods curMode = MovingMods.ForthBack;

    private void Update()
    {
        transform.position += new Vector3(0f, 0f, movingDir * movingSpeed * Time.deltaTime);
    }

    private void SwitchMovingMode()
    {
        switch (curMode)
        {
            case MovingMods.UpDown:
                UpOrDown(movingDir);
                break;
            case MovingMods.RightLeft:
                RightOrLeft(movingDir);
                break;
            case MovingMods.ForthBack:
                ForthOrBack(movingDir);
                break;
            default:
                break;
        }
    }

    private void ForthOrBack(float dir)
    {
        transform.position += new Vector3(0f, 0f, movingDir * movingSpeed * Time.deltaTime);
    }

    private void RightOrLeft(float dir)
    {
        transform.position += new Vector3(0f, 0f, movingDir * movingSpeed * Time.deltaTime);
    }

    private void UpOrDown(float dir)
    {
        transform.position += new Vector3(0f, 0f, movingDir * movingSpeed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Tag>().Tags.Contains(Tags.Player))
        {

        }
    }
}
