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
        setStartValues("Dead");
    }

    public override string Exit(string name)
    {
        return "";
    }
}
