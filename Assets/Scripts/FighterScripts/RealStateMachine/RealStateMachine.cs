using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class RealStateMachine
    {
        public StateObject CurrentState { get; private set; }

        public void Initialize(StateObject startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
            Debug.Log(CurrentState + " fuck starting stat");
        }

        public void ChangeState(StateObject newState)
        {
            CurrentState.Exit();
            Debug.Log(CurrentState + " fuck state changed");
            CurrentState = newState;
            newState.Enter();

        }
    }
