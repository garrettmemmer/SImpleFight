
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttack : Grounded
{
    
    private float _horizontalInput;



    public GroundAttack(MovementSM stateMachine) : base("LowKick", "Attacking", stateMachine) {
        //_sm = stateMachine;
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
        
        if (_sm.isAnimated == true)
        {
            _sm.ChangeAnimationState("SFLK");   
        }
        _sm.Invoke("AnimationComplete", 1f);
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
     public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }    
}