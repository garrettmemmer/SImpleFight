using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RealAttackingState : StateObject
{
    //Variables
    private bool attackpressed;

    public RealAttackingState(BeanController beanCharacter, RealStateMachine stateMachine) : base(beanCharacter, stateMachine)
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
        attackpressed = HandleInput.GetButton("Fire3");
        //for now, we want this to decect left shift for attacking
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //any logic that would keep us in this state or transfer to another

        //attack animation complete
            //transition back to standing

        //hurtbox hit by enemy hitbox
            //transition to hit/tumble
    }

    public override void PhysicsUpdate()
    {
        //base.PhysicsUpdate();
        // any logic that would change the character physics for attacking
    }

}