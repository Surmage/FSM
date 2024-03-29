using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Social : State
{
    public override void Execute(string name)
    {
        //Change stat variables
        speed = im.speed;
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();        
        agentBehavior.changeEnergy(energyChangeVal * speed);
        agentBehavior.changeHappiness(0.5f * speed);
        agentBehavior.busy = true;
        agentBehavior.changeHunger(0.5f * speed);
        agentBehavior.changeThirst(0.5f * speed);
        agentBehavior.busy = false;
    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Social state");
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        //"busy" being true prevents state from changing
        agentBehavior.busy = true;
        agentBehavior.changeMoney(-1000);
        agentBehavior.changeHappiness(1000);
        agentBehavior.busy = false;
        setStartValues("socializing");    
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Social state");
        return dateWith;
    }
}
