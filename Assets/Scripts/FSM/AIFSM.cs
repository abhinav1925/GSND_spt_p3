using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 需要FSM内声明变量，更新变量值
/// State列表: Idle, Chase
/// </summary>
[System.Serializable]
public class AIFSM : FSM
{
    public Transform CurTarget;
    public float MoveSpeed;
    public Transform SelfTrans;

    public AIFSM()
    {
        AddState(new IdleState("Idle",this));
        AddState(new ChaseState("Chase", this));
    }
}

public abstract class AIState : State
{
    protected AIFSM m_CurFSM;

    public AIState(string name, AIFSM FSM) : base(name, FSM)
    {
        m_CurFSM = FSM;
    }
}

public class IdleState : AIState
{
    public IdleState(string name, AIFSM FSM) : base(name, FSM)
    {
        
    }

    public override void OnEnter()
    {

        Debug.Log("进入Idle");
    }

    public override void OnExit()
    {
        Debug.Log("退出Idle");
    }

    public override void OnUpdate()
    {
        Debug.Log("正在Idle");
    }
}

public class ChaseState : AIState
{
    public ChaseState(string name, AIFSM FSM) : base(name, FSM)
    {
        
    }

    public override void OnEnter()
    {
        
        Debug.Log("进入Chase");
    }

    public override void OnExit()
    {
        Debug.Log("退出Chase");
    }

    public override void OnUpdate()
    {
        m_CurFSM.SelfTrans.position = Vector3.MoveTowards(m_CurFSM.SelfTrans.position, m_CurFSM.CurTarget.position, m_CurFSM.MoveSpeed * Time.deltaTime);
        Debug.Log("正在Chase");
    }
}

