using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : State
{
    public override void Execute(string name)
    { 
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        act.changeEnergy(-0.25f * speed);
        act.changeHunger(-0.2f * speed);
        act.changeThirst(-0.5f * speed);
        act.changeMoney(0.3f * speed);
        act.changeHappiness(-0.2f * speed);
    }
    public override void Enter(string name)
    {
        setStartValues("Mine");
        actor = GameObject.Find(name);
        var act = actor.GetComponent<Actor>();
        if (act.needRepair)
        {
            Debug.Log(name + " Payed 1500 for new pickaxe before " + act.money + " with status: " + act.status);
            act.busy = true;
            act.needRepair = false;
            act.changeMoney(-1500);          
            act.busy = false;
            Debug.Log(name + " Payed 1500 for new pickaxe after " + act.money);           
        }
    }

    public override string Exit(string name)
    {        
        int pickaxeBreakChance = Random.Range(0, 11);
        //Debug.Log(pickaxeBreakChance);
        if(pickaxeBreakChance == 0)
        {
            //Debug.Log("Broke");
            actor = GameObject.Find(name);
            var act = actor.GetComponent<Actor>();
            act.needRepair = true;
            if(act.money >= 3000)
            {
                act.changeMoney(-1500);
                act.needRepair = false;
                Debug.Log("Repaired broken pickaxe");
            }
        }
        return next;
    }
}
