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
        if (recAct.money >= 2000 && recAct.canISocial() && recAct.busy == false && recAct.status != "Dead")
        {        
            msg = "Yes";
        }
        else
        {
            msg = "Can't because I am " + recAct.getStatus();
            
        }
        return msg;
    }
    public State changeState(string cause, State s, Actor caller)
    {
        
        if (s.Exit(caller.name) != "")
        {
            //Debug.Log(s.next);
            string friend = s.next;

            for (int i = 0; i < 4; i++)
            {
                if (friend == friends[i].name)
                {
                    friends[i].GetComponent<Actor>().status = "Bored";
                    friends[i].GetComponent<Actor>().enterSocial();
                }
            }
            caller.status = "Bored";
            s = states[4].GetComponent<Social>();
            return s;

        }
        if (cause == "Bored" && caller.GetComponent<Actor>().canSocial == true)
        {
            if (caller.money >= 1000)
            {
                if (s.type != "Social")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (caller.name != friends[i].name)
                        {
                            if (dispatchMessage(0, caller.name, friends[i].name, "") == "Yes")
                            {
                                //Debug.Log("WOwie");
                                friends[i].GetComponent<Actor>().s.setNextState(friends[i].name);
                                s = states[4].GetComponent<Social>();
                                return s;
                            }
                        }
                    }
                    //This needs work, fix it
                    StartCoroutine(caller.setCanSocial(10));
                    cause = caller.isAnythingLow();
                }

            }
            else //this too
            {
                StartCoroutine(caller.setCanSocial(10));
                cause = caller.isAnythingLow();              
            }
        }
        if (cause == "Hungry")
        {
            s = states[0].GetComponent<Eat>();
            return s;

        }
        if (cause == "Sleepy")
        {
            s = states[1].GetComponent<Sleep>();
            return s;

        }
        if (cause == "Thirsty")
        {
            s = states[2].GetComponent<Drink>();
            return s;

        }
        if (cause == "Motivated")
        {
            s = states[3].GetComponent<Gather>();
            return s;

        }
        
        if (cause == "Fine")
        {
            s = states[5].GetComponent<Idle>();
            return s;

        }
        if (cause == "Poor")
        {
            s = states[6].GetComponent<Mining>();
            return s;

        }
        if (cause == "Dead")
        {
            s = states[7].GetComponent<Dead>();
            return s;
        }
        Debug.Log("Oh no");
        return s;
    }
    public State changeState(int i, State s, Actor caller)
    {
        if(s != null)
        {
            s.Exit(caller.name);
        }
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
    public bool fix(Actor caller, List<(float, string)> arr, List<(float, string)> arrCopy)
    {
        Debug.Log(caller.name + " asked for help");
        for (int i = 0; i < 4; i++)
        {
            if (caller.name != friends[i].name)
            {
                Actor friend = friends[i].GetComponent<Actor>();               
                if (friend.money >= 1500 && friend.status != "Sleep" && friend.status != "Dead") //Solution for hungry/thirsty/bored
                {                                       
                    friend.busy = true;
                    caller.busy = true;
                    //Debug.Log(caller.money);
                    friend.changeMoney(-500);
                    caller.changeMoney(500);
                    caller.changeHappiness(2000);
                    //Debug.Log(caller.money);
                    //Debug.Log("Helped");
                    friend.busy = false;
                    caller.busy = false;
                    return true;
                }
            }
        }
        return false;
        //arr contains any item that can be fixed, arrCopy contains all items

        //Debug.Log(name + " " + arr[0].Item2 + " " + arr[1].Item2);
        //string string1 = arr[0].Item2;
        //string string2 = arr[1].Item2;

        //Stats increase by a lot instantly?
        //if (!busy)
        //{
        //    StartCoroutine(setBusy(20));
        //    StartCoroutine(enterStateDelayed(0, "Thirsty"));
        //    StartCoroutine(enterStateDelayed(10, "Hungry"));
        //    StartCoroutine(enterStateDelayed(20, "Sleepy"));
        //}
        //energy = 8000;
        //fullness = 8000;
        //happiness = 8000;
        //thirst = 8000;

        //return busy;
    }
    public float getSpeed()
    {
        return speed;
    }
}
