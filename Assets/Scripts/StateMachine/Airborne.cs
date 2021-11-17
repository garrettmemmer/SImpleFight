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

/* hitstun test code
        if (_hit)
            stateMachine.ChangeState(_sm.hitStun);
        //this will go in airborne, groundattack, grounded, airattack
*/
        //new code to be tested
        //if (_ledged) 
        //    stateMachine.ChangeState(_sm.ledgeGetUpState);

        // include this from the jumping script
       // if (Input.GetKeyDown(KeyCode.LeftShift))
       // {
       //     _sm.isAnimated = true;
        //    stateMachine.ChangeState(_sm.AirAttack);
        //}
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