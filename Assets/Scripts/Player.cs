using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotateInterpolation;
    public float jumpSpeed;    
    public StateMachine stateMachine;
    public Rigidbody rigid;

    public Animal rideAnimal;
    public Transform Gaze;
    public GameObject noose;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StateMachineInit();
    }

    private void StateMachineInit()
    {
        stateMachine = new StateMachine();
        stateMachine.stateDic.Add(EState.Ride, new Player_Ride(this));
        stateMachine.stateDic.Add(EState.Jump, new Player_Jump(this));
        stateMachine.curState = stateMachine.stateDic[EState.Ride];
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}
