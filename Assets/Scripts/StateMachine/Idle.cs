﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Grounded
{    
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", "Grounded", stateMachine) {
      //_sm = stateMachine;
    }

        public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.spriteRenderer.color = Color.black;
        _sm.ChangeAnimationState("PlayerIdle");  
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.movingState);
    }
}
