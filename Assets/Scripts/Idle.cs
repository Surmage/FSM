using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public override void Execute(string name)
    {

        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.changeEnergy(-0.2f * speed);
        act.changeHunger(-0.3f * speed);
        act.changeThirst(-1f * speed);
        act.changeHappiness(-0.3f * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Idle");

    }

    public override string Exit(string name)
    {
        return next;

    }
}
