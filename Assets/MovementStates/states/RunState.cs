using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunState : MovementBaseState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Running", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walk);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (movement.vInput < 0) movement.currentMoveSpeed = movement.runBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
