using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    public StateMachine stateMachine;
    public Rigidbody rigid;
    public Player ridePlayer;
    public NavMeshAgent navMeshAgent;
    public Transform target;

    [SerializeField] public float idleSpeed;
    [SerializeField] public float rideSpeed;
    [SerializeField] public float jumpPower;
    [SerializeField] public float angryTime;
    public float progressTime;

    public bool isAngry;
    public bool isRide;
    public bool canEat;
    public bool canThrow;
    public Transform saddle;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StateMachineInit();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void StateMachineInit()
    {
        stateMachine = new StateMachine();
        stateMachine.stateDic.Add(EState.Ride, new Animal_Ride(this));
        stateMachine.stateDic.Add(EState.Idle, new Animal_Idle(this));
        stateMachine.stateDic.Add(EState.Angry, new Animal_Angry(this));
        if (isRide)
        {
            stateMachine.curState = stateMachine.stateDic[EState.Ride];
        }
        else 
        {
            stateMachine.curState = stateMachine.stateDic[EState.Idle];
        }
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isRide) 
        {
            if (canEat)
            {
                if(collision.gameObject.CompareTag("Animal"))
                {
                    // 대상 동물 비활성화, 현재 동물 속도 증가
                }
            }

            if (collision.gameObject.CompareTag("Obstacle") || 
                collision.gameObject.CompareTag("Animal"))
            {
                // gameOver = true;
            }


        }
    }

    public void Ride(Player player)
    {
        ridePlayer = player;
        stateMachine.ChangeState(stateMachine.stateDic[EState.Ride]);
    }
}
