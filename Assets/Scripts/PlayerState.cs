using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
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
        player.rigid.useGravity = false;
        player.rideAnimal.ridePlayer = player;
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
        player.rigid.useGravity = true;
        // Vector3 jumpVector = player.transform.forward * player.jumpSpeed + Vector3.up * player.rideAnimal.jumpPower;
        
        player.rigid.AddForce(Vector3.up * player.rideAnimal.jumpPower, ForceMode.Impulse);
        player.rigid.AddForce(player.transform.forward * player.jumpSpeed, ForceMode.Impulse);
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
        player.isJump = true;
        player.noose.gameObject.SetActive(true);
    }
    public override void Update() 
    {
        if (player.noose.target != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.rideAnimal = player.noose.target.GetComponentInParent<Animal>();
                if (player.rideAnimal != null)
                {
                    player.rideAnimal.Ride(player);
                    player.stateMachine.ChangeState(player.stateMachine.stateDic[EState.Ride]);
                }

            }
        }
    }


    public override void FixedUpdate() 
    {
        Vector3 noosePosition = player.transform.position + (player.rigid.transform.forward * player.transform.position.y) - Vector3.up * player.transform.position.y;
        player.noose.transform.position = noosePosition;
    }
    public override void Exit() 
    {
        player.isJump = false;
        player.noose.gameObject.SetActive(false);
    }
}
