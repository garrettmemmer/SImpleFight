using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airborne : BaseState
{
    protected MovementSM _sm;

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
    } 

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        _grounded = _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }
}