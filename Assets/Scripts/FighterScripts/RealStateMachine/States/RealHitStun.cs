using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RealHitStun : StateObject
    {
        protected float speed;
        protected float rotationSpeed;

        protected float hitStunTimer; 

        //private float horizontalInput;
        //private float verticalInput;

        public RealHitStun(BeanController beanCharacter, RealStateMachine stateMachine) : base(beanCharacter, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //horizontalInput = verticalInput = 0.0f;
        }

        public override void Exit()
        {
            base.Exit();
            //beanCharacter.ResetMoveParams();
        }

        public override void HandleInput()
        {
            //if hitStunTimer < 0 
            base.HandleInput();
            //verticalInput = Input.GetAxis("Vertical");
            //horizontalInput = Input.GetAxis("Horizontal");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            //beanCharacter.Move(verticalInput * speed, horizontalInput * rotationSpeed);
        }
    }

