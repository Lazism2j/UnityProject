using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public StateMachine stateMachine;
    public Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StateMachineInit();
    }

    private void StateMachineInit()
    {
        stateMachine = new StateMachine();
        stateMachine.stateDic.Add(EState.Ride, new Animal_Ride(this));
        stateMachine.stateDic.Add(EState.Idle, new Animal_Idle(this));
        stateMachine.stateDic.Add(EState.Angry, new Animal_Angry(this));
        stateMachine.curState = stateMachine.stateDic[EState.Idle];
    }
}
