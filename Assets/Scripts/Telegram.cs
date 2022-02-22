using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telegram : MonoBehaviour
{
    string msg = "";
    GameObject interfaceM;
    [SerializeField] public List<GameObject> states = new List<GameObject>();
    [SerializeField] public List<GameObject> friends = new List<GameObject>();

    float speed;
    void Start()
    {
        interfaceM = GameObject.Find("InterfaceManager");
        InterfaceManager im = interfaceM.GetComponent<InterfaceManager>();
        speed = im.speed;
        //Debug.Log(friends[1].GetComponent<Actor>().name);

    }
    public string dispatchMessage(float delay, string senderName, string receiverName, string incMsg)
    {
        GameObject sender = GameObject.Find(senderName);
        GameObject receiver = GameObject.Find(receiverName);
        
        var sendAct = sender.GetComponent<Actor>();
        var recAct = receiver.GetComponent<Actor>();
        if (recAct.canISocial() && recAct.busy == false)
        {        
            msg = "Yes";
        }
        else
        {
            msg = "Can't because I am " + recAct.getStatus();
        }
        //Debug.Log(msg);
        return msg;
    }
    public State changeState(string cause, State s, Actor caller)
    {
        if (s.Exit(cause) != "")
        {
            //Debug.Log(s.next);
            string friend = s.next;

            for (int i = 0; i < 4; i++)
            {
                if (friend == friends[i].name)
                {
                    friends[i].GetComponent<Actor>().enterSocial();
                }
            }
            s = states[4].GetComponent<Social>();
            return s;

        }
        if (cause == "Hungry")
        {
            s = states[0].GetComponent<Eat>();
        }
        if (cause == "Sleepy")
        {
            s = states[1].GetComponent<Sleep>();
        }
        if (cause == "Thirsty")
        {
            s = states[2].GetComponent<Drink>();
        }
        if (cause == "Motivated")
        {
            s = states[3].GetComponent<Gather>();
        }
        if (cause == "Bored" && caller.GetComponent<Actor>().canSocial == true)
        {
            if (s.type != "Social")
            {
                for (int i = 0; i < 4; i++)
                {
                    if (caller.name != friends[i].name)
                    {
                        if (dispatchMessage(0, caller.name, friends[i].name, "") == "Yes") //Never fails? Fix this...
                        {
                            //Debug.Log("WOwie");
                            friends[i].GetComponent<Actor>().s.setNextState(friends[i].name);
                            s = states[4].GetComponent<Social>();
                        }
                    }
                }
                StartCoroutine(caller.setCanSocial(10));
                //Debug.Log("oh no");
            }
        }
        if (cause == "Fine")
        {
            s = states[5].GetComponent<Idle>();
        }
        if (cause == "Poor")
        {
            s = states[6].GetComponent<Mining>();
        }
        if (cause == "Dead")
        {
            s = states[7].GetComponent<Dead>();
        }
        return s;
    }
    public State changeState(int i)
    {
        State s = null;
        if (i == 0)
        {
            s = states[0].GetComponent<Eat>();
        }
        if (i == 1)
        {
            s = states[1].GetComponent<Sleep>();
        }
        if (i == 2)
        {
            s = states[2].GetComponent<Drink>();
        }
        if (i == 3)
        {
            s = states[3].GetComponent<Gather>();
        }
        if (i == 4)
        {
            s = states[4].GetComponent<Social>();
        }
        if (i == 5)
        {
            s = states[5].GetComponent<Dead>();
        }

        return s;
    }
    public float getSpeed()
    {
        return speed;
    }
}
