using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : State
{

    public override void Execute(string name)
    {
        //Change stat variables
        speed = im.speed;
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        agentBehavior.changeEnergy(-0.25f * speed);
        agentBehavior.changeThirst(3 * speed);

    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Drink state");
        setStartValues("drinking");
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Drink state");
        return dateWith;
    }
}
