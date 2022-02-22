using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public string type;
    public float speed;
    public GameObject actor;
    public GameObject manager;
    public InterfaceManager im;
    public Actor ac;
    public string next;

    // Start is called before the first frame update
    public abstract void Enter(string name);

    public abstract void Execute(string name);

    public abstract string Exit(string name);

    public void problem()
    {
        Debug.Log("Found");
    }
    public void changeText(string output)
    {
        //Debug.Log(output);
    }
    public void setStartValues(string type)
    {

        manager = GameObject.Find("InterfaceManager");
        im = manager.GetComponent<InterfaceManager>();        
        speed = im.speed;
        this.type = type;
        next = "";
    }
    public void setNextState(string next)
    {
        this.next = next;
    }
}
