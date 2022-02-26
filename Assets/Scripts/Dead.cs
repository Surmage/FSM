using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : State
{
    public override void Execute(string name)
    {

    }
    public override void Enter(string name)
    {
        Debug.Log(name + " entering Dead state");
        setStartValues("dead");
    }

    public override string Exit(string name)
    {
        Debug.Log(name + " exiting Dead state");
        return "";
    }
}
