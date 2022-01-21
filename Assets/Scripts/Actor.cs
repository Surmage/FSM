using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int hunger;
    public int thirst;
    public GameObject messager;
    // Start is called before the first frame update
    void Start()
    {
        hunger = 3000;
        thirst = 500;
        messager = GameObject.Find("StateManager");       
    }

    // Update is called once per frame
    void Update()
    {
        if(hunger < 0)
        {
            hunger = 0;
        }
        if (hunger > 3000)
        {
            hunger = 3000;
        }
        if (thirst < 0)
        {
            thirst = 0;
        }
        if (thirst > 500)
        {
            thirst = 500;
        }
        //Debug.Log("Hunger" + hunger + ", Thirst" + thirst);
    }
    public void changeHunger(int change)
    {
        if (hunger >= 0 && hunger <= 3000)
        {
            hunger += change;
            if(hunger <= 500)
            {
                //Change
                messager.GetComponent<StateManager>().changeState("Hungry");
            }
            if (amIFine())
            {
                messager.GetComponent<StateManager>().changeState("Poor");
            }
        }
    }
    public void changeThirst(int change)
    {
        if(thirst >= 0 && thirst <= 500)
        {
            thirst += change;
            if(thirst <= 100)
            {
                //Change
                messager.GetComponent<StateManager>().changeState("Thirsty");
            }
            if (amIFine())
            {
                messager.GetComponent<StateManager>().changeState("Poor");
            }
        }      
    }
    bool amIFine()
    {
        string type = messager.GetComponent<StateManager>().type;
        if(type == "Drink")
        {
            if(thirst >= 300)
            {
                return true;
            }
        }
        if(type == "Eat")
        {
            if (hunger >= 2500)
            {
                return true;
            }
        }
        return false;
    }
}
