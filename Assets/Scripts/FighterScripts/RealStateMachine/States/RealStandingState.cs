using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RealStandingState : RealGroundedState
    {
        private bool jump;
        private bool lowKick;

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
        }

        public override void HandleInput()
        {
            base.HandleInput();
            lowKick = Input.GetButtonDown("Fire3");
            jump = Input.GetButtonDown("Jump");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (lowKick)
            {
                stateMachine.ChangeState(beanCharacter.ducking);
            }
            else if (jump)
            {
                //stateMachine.ChangeState(beanCharacter.jumping);
            }
        }
    }
