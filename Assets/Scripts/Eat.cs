using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : State
{  

    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.changeEnergy(-0.3f * speed);
        act.changeHunger(1 * speed);
        act.changeThirst(1 * speed);     
        act.changeMoney(-1 * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Eat");
    }

    public override void Exit(string name)
    {
    }
}
