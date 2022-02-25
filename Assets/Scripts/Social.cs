using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Social : State
{
    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        //act.changeMoney(-0.3f * speed); //remove later
        act.changeEnergy(-0.25f * speed);
        act.changeHappiness(0.5f * speed);
        act.changeHunger(0.5f * speed);
        act.changeThirst(0.5f * speed);

    }
    public override void Enter(string name)
    {
        //Debug.Log(name + " entering social");
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.busy = true;
        act.changeMoney(-1000);
        act.busy = false;
        setStartValues("Social");    
    }

    public override string Exit(string name)
    {
        return next;
    }
}
