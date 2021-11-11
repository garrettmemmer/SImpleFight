using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : BaseState
{
    protected MovementSM _sm;

    public Attacking(string name, string primaryName, MovementSM stateMachine) : base(name, primaryName, stateMachine) 
    {
        _sm = (MovementSM)stateMachine;
    }



    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.isAnimated)
            stateMachine.ChangeState(_sm.idleState);


    }
}
