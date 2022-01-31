using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Social : State
{
    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        actor.GetComponent<Actor>().changeEnergy(-0.3f * speed);
        actor.GetComponent<Actor>().changeHunger(-1 * speed);
        actor.GetComponent<Actor>().changeThirst(-1 * speed);       
        actor.GetComponent<Actor>().changeMoney(-2 * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Social");
    }

    public override void Exit(string name)
    {
    }
}
