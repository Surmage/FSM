using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : State
{
    // Start is called before the first frame update
    public override void Execute(string name)
    {
        actor = GameObject.Find(name);
        //60 per second,         
        actor.GetComponent<Actor>().changeHunger(-0.01f * speed);
        actor.GetComponent<Actor>().changeThirst(-0.01f * speed);
        actor.GetComponent<Actor>().changeEnergy(0.425f * speed); //20 seconds, 86400, 600 per second
        //decrease hunger and thirst but only if they are above a specific amount, like 500                                                        
    }
    public override void Enter(string name)
    {
        setStartValues("Sleep");
      


    }

    public override void Exit(string name)
    {
    }
}
