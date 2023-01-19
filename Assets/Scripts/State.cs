using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public string type;
    public float speed;
    public float energyChangeVal;
    public GameObject agent;
    public GameObject manager;
    public InterfaceManager im;
    public string dateWith;

    public abstract void Enter(string name);

    public abstract void Execute(string name);

    public abstract string Exit(string name);

    public void setStartValues(string type)
    {
        manager = GameObject.Find("InterfaceManager");
        im = manager.GetComponent<InterfaceManager>();        
        speed = im.speed;
        this.type = type;
        dateWith = "";
        energyChangeVal = -0.22f;
    }
    public void setDate(string next)
    {
        this.dateWith = next;
    }
}
