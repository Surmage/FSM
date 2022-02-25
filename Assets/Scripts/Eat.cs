using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : State
{
    int foodValue;
    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.changeEnergy(-0.25f * speed);
        act.changeHunger(0.5f * foodValue * speed);
        act.changeThirst(1 * speed);
        act.changeHappiness(0.05f * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Eat");
        foodValue = Random.Range(1, 5);
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.busy = true;
        act.changeMoney(-500);
        act.busy = false;
    }

    public override string Exit(string name)
    {
        if(next != "")
        {
            //Debug.Log("Going to: " + next);
        }
        return next;
    }
}
