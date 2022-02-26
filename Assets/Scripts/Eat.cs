using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : State
{
    int foodValue;
    public override void Execute(string name)
    {
        //Change stat variables
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        agentBehavior.changeEnergy(-0.25f * speed);
        agentBehavior.changeHunger(0.5f * foodValue * speed);
        agentBehavior.changeThirst(1 * speed);
        agentBehavior.changeHappiness(0.05f * speed);
    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Eat state");
        setStartValues("eating");
        foodValue = Random.Range(1, 5);
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        //"busy" being true prevents state from changing
        agentBehavior.busy = true;
        //Pay for food
        agentBehavior.changeMoney(-500);
        agentBehavior.busy = false;
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Eat state");
        return dateWith;
    }
}
