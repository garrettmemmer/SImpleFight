
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttack : BaseState
{
    protected MovementSM _sm;
    
    private float _horizontalInput;



    public GroundAttack(string name, string primaryName, MovementSM stateMachine) : base("GroundAttack", "Grounded", stateMachine) {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.spriteRenderer.color = Color.blue;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _sm.isAnimated = true;
            _sm.isLowKicking = true;
            stateMachine.ChangeState(_sm.lowKick);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _sm.isAnimated = true;
            _sm.isHeavyKicking = true;
            stateMachine.ChangeState(_sm.lowKick);
        }
        /*
        if (_sm.isAnimated == true && _sm.isLowKicking == true)
        {
            _sm.ChangeAnimationState("SFLK");   
        }
        if (_sm.isAnimated == true && _sm.isHeavyKicking == true)
        {
            _sm.ChangeAnimationState("SfHkFull");   
        }
       
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
        */
    }
     public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }    
}