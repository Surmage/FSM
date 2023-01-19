using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : State
{
    public override void Execute(string name)
    {
        //Change stat variables
        speed = im.speed;
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        agentBehavior.busy = true;
        agentBehavior.changeHunger(-0.01f * speed);
        agentBehavior.changeThirst(-0.02f * speed);
        agentBehavior.busy = false;
        agentBehavior.changeEnergy(-energyChangeVal * 2 * speed); 
    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Sleep state");
        setStartValues("sleeping");
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Sleep state");
        return dateWith;
    }
}
