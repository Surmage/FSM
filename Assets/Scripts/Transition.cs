using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : State
{
    State s;
    public override void Execute(string name)
    {     
        //actor = GameObject.Find(name);
        //ac = actor.GetComponent<Actor>();
        ////ac.transitioning = true;
        ////ac.changeHunger(-1 * speed);
        ////ac.changeThirst(-1 * speed);
        ////ac.changeEnergy(-0.3f * speed);
        
    }
    public override void Enter(string name)
    {
        ////Debug.Log(name + " entering transition");
        //setStartValues("Transition");
        //actor = GameObject.Find(name);
        //ac = actor.GetComponent<Actor>();
    }

    public override void Exit(string name)
    {       
        //s = sm.changeState(next, s);    
        //actor = GameObject.Find(name);
        //ac = actor.GetComponent<Actor>();
        //s.Enter(name);
        //ac.setState(s);
        ////Debug.Log(next);
        //ac.busy = false;
        ////Debug.Log(ac.type);
        ////s.Exit();   
    }
    
}
