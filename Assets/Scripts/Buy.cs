using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : State
{

    public override void Execute(string name)
    {       
        actor = GameObject.Find(name);
        actor.GetComponent<Actor>().changeEnergy(-0.3f * speed);
        actor.GetComponent<Actor>().changeMoney(-1 * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Eat");
    }

    public override void Exit(string name)
    {
    }
}
