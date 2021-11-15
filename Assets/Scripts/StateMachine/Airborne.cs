using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : BaseState
{
    protected MovementSM _sm;
    private float _horizontalInput;
    private bool _grounded;
    private int _groundLayer = 1 << 9;

    public Airborne(string name, string primaryName, MovementSM stateMachine) : base(name, primaryName, stateMachine) {
        _sm = (MovementSM)stateMachine;
    }


    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_grounded)
            stateMachine.ChangeState(_sm.idleState);
        _horizontalInput = Input.GetAxis("Horizontal");

    } 

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.rigidbody.velocity;
        vel.x = _horizontalInput * ((MovementSM)stateMachine).speed;
        _sm.rigidbody.velocity = vel;
        _grounded = _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }
}