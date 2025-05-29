using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    // ���µ��� ������ ���� ���̴�.
    public Dictionary<EState, BaseState> stateDic;
    // �� ���¸� �޾Ƽ� ���ǿ� ���� ������ ���̽��� �� ���̴�.
    public BaseState curState;

    public StateMachine()
    {
        stateDic = new Dictionary<EState, BaseState>();
    }

    public void ChangeState(BaseState changedState)
    {
        if (changedState == curState) { return; }

        curState.Exit();
        curState = changedState;
        curState.Enter();
    }
    // �� ������ Enter, Update, Exit....�� ������� �� ���̴�.

    public void Update() => curState.Update();

    public void FixedUpdate()
    {
        curState.FixedUpdate();
    }
}
