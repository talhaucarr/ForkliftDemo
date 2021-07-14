using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFuelModule
{
    void DecreaseFuel(float fuelAmount);
    void IncreaseFuel(float fuelAmount);
}
