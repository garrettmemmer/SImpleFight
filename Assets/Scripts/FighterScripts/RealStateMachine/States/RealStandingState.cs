using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RealStandingState : RealGroundedState
    {
        private bool jump;
        private bool lowKick;
        private bool dodge;

        public RealStandingState(BeanController beanCharacter, RealStateMachine stateMachine) : base(beanCharacter, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //speed = beanCharacter.MovementSpeed;
            //rotationSpeed = beanCharacter.RotationSpeed;
            lowKick = false;
            jump = false;
            dodge = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            lowKick = Input.GetButtonDown("Fire3");
            dodge = Input.GetButtonDown("Jump");
            //jump = Input.GetButtonDown("Jump");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (lowKick)
            {
                stateMachine.ChangeState(beanCharacter.ducking);
                //Debug.Log("low kick input from standing state");
            }
            else if (jump)
            {
                //stateMachine.ChangeState(beanCharacter.jumping);
            }
            else if(dodge)
            {
                //stateMachine.ChangeState(beanCharacter.dodging);
                //Debug.Log("dodge input from standing state");
                
            }
        }
    }
