using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : State
{

    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        actor.GetComponent<Actor>().changeEnergy(-0.3f * speed);
        actor.GetComponent<Actor>().changeThirst(4 * speed);
        
    }
    public override void Enter(string name)
    {
        setStartValues("Drink");



    }

    public override void Exit(string name)
    {
    }
}
