using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   public class RealDuckingState : RealGroundedState
    {
        private bool belowCeiling;
        private bool crouchHeld;

        public RealDuckingState(BeanController beanCharacter, RealStateMachine stateMachine) : base(beanCharacter, stateMachine)
        { 
        }

        public override void Enter()
        {
            base.Enter();
           // beanCharacter.SetAnimationBool(character.crouchParam, true);
          //  speed = beanCharacter.CrouchSpeed;
           /// rotationSpeed = character.CrouchRotationSpeed;
           // beanCharacter.ColliderSize = character.CrouchColliderHeight;
           // belowCeiling = false;
        }

        public override void Exit()
        {
            base.Exit();
            //character.SetAnimationBool(character.crouchParam, false);
            //character.ColliderSize = character.NormalColliderHeight;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            crouchHeld = Input.GetButton("Fire3");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!(crouchHeld || belowCeiling))
            {
                stateMachine.ChangeState(beanCharacter.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            //base.PhysicsUpdate();
            //belowCeiling = character.CheckCollisionOverlap(character.transform.position +
            //    Vector3.up * character.NormalColliderHeight);
        }
    }

