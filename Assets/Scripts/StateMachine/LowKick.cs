using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LowKick : GroundAttack
{

    public LowKick(MovementSM stateMachine) : base("LowKick", "GroundAttack", stateMachine) {
        //_sm = stateMachine;
    }

//Test this new enter method over the updatelogic method
/*
    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        //_sm.spriteRenderer.color = Color.black;
        _sm.ChangeAnimationState("SFLK");  
    }
*/

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (_sm.isAnimated == true && _sm.isLowKicking == true)
        {
            _sm.ChangeAnimationState("SFLK");   
        }
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false) //should this call the exit function? and then in Exit we change the state?
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
}

/* create these states and implement
public class HeavyKick : GroundAttack
{
    public HeavyKick(MovementSM stateMachine) : base("HeavyKick", "GroundAttack", stateMachine) {
        //_sm = stateMachine;
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (_sm.isAnimated == true && _sm.isHeavyKicking == true)
        {
            _sm.ChangeAnimationState("SfHKFull");   
        }
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
}

public class LedgeAttack : GroundAttack
{
    public LedgeAttack(MovementSM stateMachine) : base("LedgeAttack", "GroundAttack", stateMachine) {
        //_sm = stateMachine;
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (_sm.isAnimated == true && _sm.isLedgeAttacking == true)
        {
            _sm.ChangeAnimationState("SfLedgeAttack");   
        }
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
}
*/