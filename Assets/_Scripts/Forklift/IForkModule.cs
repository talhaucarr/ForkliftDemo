using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IForkModule
{
    void Lift(float vertical);
    void PickUp();
    void PutDown();
}
