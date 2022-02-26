using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : State
{
    public override void Execute(string name)
    {
        //Change stat variables
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        agentBehavior.changeEnergy(-0.25f * speed);
        agentBehavior.changeHunger(-0.2f * speed);
        agentBehavior.changeThirst(-0.5f * speed);
        agentBehavior.changeMoney(0.1f * speed);
        agentBehavior.changeHappiness(-0.1f * speed);
    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Gather state");
        setStartValues("gathering");
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Gather state");
        return dateWith;

    }
}
