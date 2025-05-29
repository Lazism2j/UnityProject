using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : BaseState
{
    protected Player player;
    public PlayerState(Player _player)
    {
        player = _player;
    }
    public override void Enter() { }
    public override void Update() { }


    public override void FixedUpdate() { }
    public override void Exit() { }
}

public class Player_Ride : PlayerState
{
    
    public Player_Ride(Player _player) : base (_player)
    {
        this.player = _player;
    }
    public override void Enter() 
    {
        
    }
    public override void Update() 
    {
        float rotateInput = Input.GetAxis("Horizontal");
        player.transform.Rotate(Vector3.up, rotateInput * player.rotateInterpolation); 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.stateMachine.ChangeState(player.stateMachine.stateDic[EState.Jump]);
        }

    }


    public override void FixedUpdate() 
    {
        player.transform.position = player.rideAnimal.saddle.position;
        
    }
    public override void Exit() 
    {
        Debug.Log(player.transform.forward * player.rideAnimal.rideSpeed + Vector3.up * player.rideAnimal.jumpPower);
        player.rigid.AddForce(player.transform.forward * player.rideAnimal.rideSpeed + Vector3.up * player.rideAnimal.jumpPower, ForceMode.Impulse);
        player.rideAnimal = null;   
    }
}

public class Player_Jump : PlayerState
{
    public Player_Jump(Player _player) : base(_player)
    {
        this.player = _player;
    }
    public override void Enter() 
    {
        
    }
    public override void Update() { }


    public override void FixedUpdate() { }
    public override void Exit() { }
}
