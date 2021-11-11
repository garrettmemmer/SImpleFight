using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine2 : MonoBehaviour
{
    BaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }
    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }



    private void OnGUI()
    {
        //GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        string content2 = currentState != null ? currentState.primaryName : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{"State: " + content2}</size></color>");
        GUILayout.Label($"<color='black'><size=40>{"SubState: " + content}</size></color>");
        //GUILayout.EndArea();
    }
}