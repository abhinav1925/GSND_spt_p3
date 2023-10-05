using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    protected State m_CurState;
    public State CurState { get { return m_CurState; } }

    public Dictionary<string, State> StatesDic;

    public FSM() 
    {
        StatesDic = new Dictionary<string, State>();
    }

    public void AddState(State newState)
    {
        if(StatesDic.ContainsKey(newState.Name))
        {
            Debug.LogWarning("Already contains this State: " + newState.Name);
            return;
        }

        StatesDic.Add(newState.Name, newState);
    }

    public void SwitchState(State toState)
    {
        if (m_CurState == null)
        {
            m_CurState = StatesDic[toState.Name];
            m_CurState.OnEnter();
        }

        if (toState == m_CurState)
        {
            Debug.Log("Same State");
            return;
        }

        if (!StatesDic.ContainsKey(toState.Name))
        {
            Debug.LogError("Doesn't contain this State: " + toState.Name);
            return;
        }
        else
        {
            m_CurState.OnExit();
            m_CurState = StatesDic[toState.Name];
            m_CurState.OnEnter();
        }
    }

    public void SwitchState(string StateName)
    {
        if (m_CurState == null)
        {
            m_CurState = StatesDic[StateName];
            m_CurState.OnEnter();
        }

        if (StateName == m_CurState.Name)
        {
            Debug.Log("Same State");
            return;
        }

        if (!StatesDic.ContainsKey(StateName))
        {
            Debug.LogError("Doesn't contain this State: " + StateName);
            return;
        }
        else
        {
            m_CurState.OnExit();
            m_CurState = StatesDic[StateName];
            m_CurState.OnEnter();
        }
    }

    public bool IsStateNow(string StateName)
    {
        if(string.Equals(m_CurState.Name,StateName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnUpdate()
    {
        m_CurState.OnUpdate();
    }
}

public abstract class State
{
    public string Name;

    public State(string name, FSM FSM)
    {
        this.Name = name;
    }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract void OnUpdate();
}
