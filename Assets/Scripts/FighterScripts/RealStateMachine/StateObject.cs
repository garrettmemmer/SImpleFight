using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class StateObject
    {

        protected BeanController beanCharacter;
        protected RealStateMachine stateMachine;

        protected StateObject(BeanController beanCharacter, RealStateMachine stateMachine)
        {
            this.beanCharacter = beanCharacter;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {
            DisplayOnUI(TestUIManager.TestAlignment.Left);
            //Debug.Log("fuck Enter");
        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Exit()
        {

        }

        protected void DisplayOnUI(TestUIManager.TestAlignment testAlignment)
        {
            TestUIManager.Instance.Display(this, testAlignment);
            //Debug.Log("fuck Enter");
        }
    }
