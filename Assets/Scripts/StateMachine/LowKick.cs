using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LowKick : GroundAttack
{

    public LowKick(MovementSM stateMachine) : base("LowKick", "GroundAttack", stateMachine) {
        //_sm = stateMachine;
    }




    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (_sm.isAnimated == true && _sm.isLowKicking == true)
        {
            _sm.ChangeAnimationState("SFLK");   
        }
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
}
