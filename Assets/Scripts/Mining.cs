using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : State
{
    public override void Execute(string name)
    {
        //Change stat variables
        speed = im.speed;
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        agentBehavior.changeEnergy(-0.25f * speed);
        agentBehavior.changeHunger(-0.2f * speed);
        agentBehavior.changeThirst(-0.5f * speed);
        agentBehavior.changeMoney(0.3f * speed);
        agentBehavior.changeHappiness(-0.2f * speed);
    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Mining state");
        setStartValues("mining");
        agent = GameObject.Find(name);
        var agentBehavior = agent.GetComponent<AgentBehavior>();
        //Pay for repair
        if (agentBehavior.needRepair)
        {
            Debug.Log(name + " Payed 1500 for new pickaxe before " + agentBehavior.money);
            //"busy" being true prevents state from changing
            agentBehavior.busy = true;
            agentBehavior.needRepair = false;
            agentBehavior.changeMoney(-1500);          
            agentBehavior.busy = false;
            Debug.Log(name + " Payed 1500 for new pickaxe after " + agentBehavior.money);           
        }
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Mining state");
        //Chance for pickaxe to need repairing
        int pickaxeBreakChance = Random.Range(0, 11);
        if(pickaxeBreakChance == 0)
        {
            agent = GameObject.Find(name);
            var agentBehavior = agent.GetComponent<AgentBehavior>();
            agentBehavior.needRepair = true;
            Debug.Log(name + "'s pickaxe broke");
            //Pay for repair if possible
            if (agentBehavior.money >= 3000)
            {
                agentBehavior.changeMoney(-1500);
                agentBehavior.needRepair = false;
                Debug.Log(name + " repaired broken pickaxe");
            }
        }
        return dateWith;
    }
}
