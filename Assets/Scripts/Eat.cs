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
        act.changeEnergy(-0.3f * speed);
        act.changeHunger(foodValue * speed);
        act.changeThirst(1 * speed);     
        act.changeMoney(-1 * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Eat");
        foodValue = Random.Range(1, 5);
    }

    public override void Exit(string name)
    {
    }
}
