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
        act.changeEnergy(-0.2f * speed);
        act.changeHunger(0.5f * foodValue * speed);
        act.changeThirst(1 * speed);
        act.changeMoney(-1 * speed);
        act.changeHappiness(0.1f * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Eat");
        foodValue = Random.Range(1, 5);
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
