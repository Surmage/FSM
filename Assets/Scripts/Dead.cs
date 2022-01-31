using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : State
{
    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        actor.GetComponent<Actor>().changeEnergy(-0.3f * speed);
        actor.GetComponent<Actor>().changeHunger(-2 * speed);
        actor.GetComponent<Actor>().changeThirst(-2 * speed);
        actor.GetComponent<Actor>().changeMoney(6 * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Work");
    }

    public override void Exit(string name)
    {
    }
}