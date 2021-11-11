using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
    public string name;
    public string primaryName;
    protected StateMachine2 stateMachine;

    public BaseState(string name, string primaryName, StateMachine2 stateMachine)
    {
        this.name = name;
        this.primaryName = primaryName;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
