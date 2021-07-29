using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementModule
{
   void HandleMotor(float verticalInput, bool isBreaking);
   void HandleSteering(float horizontalInput);

   void HandleBreake(float breakeForce);
   void UpdateWheels();
}
