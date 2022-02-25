using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : State
{

    public override void Execute(string name)
    {

        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.changeEnergy(-0.25f * speed);
        act.changeThirst(3 * speed);

    }
    public override void Enter(string name)
    {
        setStartValues("Drink");



    }

    public override string Exit(string name)
    {
        return next;

    }
}
