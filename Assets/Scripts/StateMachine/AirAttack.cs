using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttack : BaseState
{

    public AirAttack(MovementSM stateMachine) : base("AirAttack", "Airborne", stateMachine) {
        //_sm = stateMachine;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        if (_sm.isAnimated == true && _sm.isAirAttacking == true)
        {
            _sm.ChangeAnimationState("SFLK");   
        }
        Debug.Log(_sm.isAnimated);


        if(_sm.isAnimated == false) //should this call the exit function? and then in Exit we change the state?
        {
            stateMachine.ChangeState(_sm.idleState);
        }
    }
    */

}
