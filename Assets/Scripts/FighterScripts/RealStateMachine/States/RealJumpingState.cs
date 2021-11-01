using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class RealJumpingState : StateObject
    {
        private bool grounded;
        private int jumpParam = Animator.StringToHash("Jump");
        private int landParam = Animator.StringToHash("Land");

        public RealJumpingState(BeanController beanCharacter, RealStateMachine realStateMachine) : base(beanCharacter, realStateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //SoundManager.Instance.PlaySound(SoundManager.Instance.jumpSounds);
            grounded = false;
            Jump();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (grounded)
            {
                //beanCharacter.TriggerAnimation(landParam);
                //SoundManager.Instance.PlaySound(SoundManager.Instance.landing);
               // stateMachine.ChangeState(beanCharacter.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            //grounded = beanCharacter.CheckCollisionOverlap(beanCharacter.transform.position);
        }

        private void Jump()
        {
            //beanCharacter.transform.Translate(Vector3.up * (beanCharacter.CollisionOverlapRadius + 0.1f));
            //beanCharacter.ApplyImpulse(Vector3.up * beanCharacter.JumpForce);
            //charabeanCharactercter.TriggerAnimation(jumpParam);
        }
    }
