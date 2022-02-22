using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : State
{
    public override void Execute(string name)
    {

        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.changeEnergy(-0.2f * speed);
        act.changeHunger(-0.2f * speed);
        act.changeThirst(-0.5f * speed);
        act.changeMoney(0.2f * speed);
        act.changeHappiness(-0.2f * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Gather");
    }

    public override string Exit(string name)
    {
        return next;

    }
}
