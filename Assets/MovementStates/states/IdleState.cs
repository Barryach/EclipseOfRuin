using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(MovementStateManager movement)
    {
        
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if(movement.dir.magnitude>0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Run);
            else movement.SwitchState(movement.Walk);
        }
        if (Input.GetKey(KeyCode.C)) movement.SwitchState(movement.Crouch);
    }
}
