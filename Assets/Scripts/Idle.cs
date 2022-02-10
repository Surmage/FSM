using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        actor.GetComponent<Actor>().changeEnergy(-0.3f * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Idle");



    }

    public override void Exit(string name)
    {
    }
}
