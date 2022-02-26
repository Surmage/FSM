using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : State
{
    public override void Execute(string name)
    {
        //Change stat variables
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        agentBehavior.changeHunger(-0.01f * speed);
        agentBehavior.changeThirst(-0.02f * speed);
        agentBehavior.changeEnergy(0.425f * speed); 
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
