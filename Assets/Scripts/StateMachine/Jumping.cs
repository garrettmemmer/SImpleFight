using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : Airborne
{
    private MovementSM _sm;
    private bool _grounded;
    private int _groundLayer = 1 << 9;

    public Jumping(MovementSM stateMachine) : base("Jumping", "Airborne", stateMachine) {
        _sm = (MovementSM)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        _sm.spriteRenderer.color = Color.green;

        Vector2 vel = _sm.rigidbody.velocity;
        vel.y += _sm.jumpForce;
        _sm.rigidbody.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _sm.isAnimated = true;
            stateMachine.ChangeState(_sm.groundAttackState);
        }
            
    } 

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}