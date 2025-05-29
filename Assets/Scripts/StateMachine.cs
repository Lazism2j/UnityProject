using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    // 상태들을 가지고 있을 것이다.
    public Dictionary<EState, BaseState> stateDic;
    // 각 상태를 받아서 조건에 따라 상태을 전이시켜 줄 것이다.
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
    // 각 상태의 Enter, Update, Exit....를 실행시켜 줄 것이다.

    public void Update() => curState.Update();

    public void FixedUpdate()
    {
        curState.FixedUpdate();
    }
}
