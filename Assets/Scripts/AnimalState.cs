using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimalState : BaseState
{
    protected Animal animal;
    public AnimalState(Animal _animal)
    {
        animal = _animal;
    }
    public override void Enter() { }
    public override void Update() { }


    public override void FixedUpdate() 
    { 
        
    }
    public override void Exit() { }
}

public class Animal_Ride : AnimalState
{
    
    public Animal_Ride(Animal _animal) : base(_animal)
    {
        this.animal = _animal;
    }
    public override void Enter() 
    {
        animal.isRide = true;
        animal.ridePlayer.rideAnimal = animal;
    }
    public override void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animal.stateMachine.ChangeState(animal.stateMachine.stateDic[EState.Idle]);
        }
    }


    public override void FixedUpdate() 
    {
        animal.transform.LookAt(animal.ridePlayer.Gaze);
        animal.rigid.velocity = animal.transform.forward * animal.rideSpeed;
    }
    public override void Exit() 
    {
        animal.isRide = false;
        animal.ridePlayer = null;
    }
}

public class Animal_Idle : AnimalState
{
    public Animal_Idle(Animal _animal) : base(_animal)
    {
        this.animal = _animal;
    }
    public override void Enter() { }
    public override void Update() { }


    public override void FixedUpdate() { }
    public override void Exit() { }
}

public class Animal_Angry : AnimalState
{
    public Animal_Angry(Animal _animal) : base(_animal)
    {
        this.animal = _animal;
    }
    public override void Enter() { }
    public override void Update() { }


    public override void FixedUpdate() { }
    public override void Exit() { }
}