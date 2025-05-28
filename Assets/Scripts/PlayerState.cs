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
    public override void Enter() { }
    public override void Update() { }


    public override void FixedUpdate() { }
    public override void Exit() { }
}

public class Player_Jump : PlayerState
{
    public Player_Jump(Player _player) : base(_player)
    {
        this.player = _player;
    }
    public override void Enter() { }
    public override void Update() { }


    public override void FixedUpdate() { }
    public override void Exit() { }
}
