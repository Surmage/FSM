using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float hunger;
    public float thirst;
    public float energy;
    public float money;
    public float happiness;
    public string type;
    public bool transitioning;
    State s;    
    public GameObject messager;
    GameObject state;
    // Start is called before the first frame update
    void Start()
    {
        transitioning = false;
        float startValue1= Random.Range(4000, 8000);
        float startValue2 = Random.Range(4000, 8000);
        float startValue3 = Random.Range(4000, 8000);
        hunger = startValue1;
        thirst = startValue1;
        energy = startValue2;
        money = startValue3;
        happiness = startValue3;
        messager = GameObject.Find("StateManager");
        int i = Random.Range(0, 5);
        s = messager.GetComponent<StateManager>().changeState(i, s); ;
        s.Enter(name);
        //Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
        s.Execute(name);
        type = s.type;
        if (hunger < 0)
        {
            hunger = 0;
        }
        if (hunger > 8000)
        {
            hunger = 8000;
        }
        if (thirst < 0)
        {
            thirst = 0;
        }
        if (thirst > 8000)
        {
            thirst = 8000;
        }
        if(energy < 0)
        {
            energy = 0;
        }
        if(energy > 8000)
        {
            energy = 8000;
        }
        if (happiness < 0)
        {
            happiness = 0;
        }
        if (happiness > 8000)
        {
            happiness = 8000;
        }
        if (hunger <= 0 && thirst <= 0)
        {
            s = messager.GetComponent<StateManager>().createTransition("Dead", s);
            s.Enter(name);
            s.setNextState("Dead");
        }
    }
    public void changeHunger(float change)
    {      
        if (hunger >= 0 && hunger <= 8000)
        {
            hunger += change;
            if (!transitioning)
            {
                if (hunger <= 500)
                {
                    //Change
                    s = messager.GetComponent<StateManager>().createTransition("Hungry", s);
                    s.Enter(name);
                    s.setNextState("Hungry");
                    return;
                }
                if (amIFine())
                {
                    s = messager.GetComponent<StateManager>().createTransition("Poor", s);
                    s.Enter(name);
                    s.setNextState("Poor");
                }
            }         
        }
    }
    public void changeThirst(float change)
    {     
        if (thirst >= 0 && thirst <= 8000)
        {
            thirst += change;
            if (!transitioning)
            {
                if (thirst <= 1000)
                {
                    //Change
                    s = messager.GetComponent<StateManager>().createTransition("Thirsty", s);
                    s.Enter(name);
                    s.setNextState("Thirsty");
                    return;
                }
                if (amIFine())
                {
                    s = messager.GetComponent<StateManager>().createTransition("Poor", s);
                    s.Enter(name);
                    s.setNextState("Poor");
                }
            }
        }      
    }
    public void changeEnergy(float change)
    {       
        if (energy >= 0 && energy <= 8000)
        {
            energy += change;
            if (!transitioning)
            {        
                //gets called every frame, stuck in transition because of energy being low
                if (energy <= 500)
                {                    
                    //Change
                    s = messager.GetComponent<StateManager>().createTransition("Sleepy", s);
                    s.Enter(name);
                    s.setNextState("Sleepy");
                    
                    return;
                }
                if (amIFine())
                {
                    s = messager.GetComponent<StateManager>().createTransition("Poor", s);
                    s.Enter(name);
                    s.setNextState("Poor");
                }
            }
        }
    }
    public void changeMoney(float change)
    {        
        money += change;
        if (!transitioning)
        {
            //if too low
            if (money <= 500)
            {
                //Change
                s = messager.GetComponent<StateManager>().createTransition("Poor", s);
                s.Enter(name);
                s.setNextState("Poor");
                return;
            }
            //if too high
            if (amIFine())
            {
                s = messager.GetComponent<StateManager>().createTransition("Social", s);
                s.Enter(name);
                s.setNextState("Social");
            }
            
        }
        
    }
    public void setState(State s)
    {
        this.s = s;
    }
    bool amIFine()
    {
        //string type = messager.GetComponent<StateManager>().type;
        if(type == "Drink")
        {
            if(thirst >= 6000)
            {
                return true;
            }
        }
        if(type == "Eat")
        {
            if (hunger >= 7000)
            {
                return true;
            }
        }
        if(type == "Sleep")
        {
            if(energy >= 7500)
            {
                return true;
            }
        }
        if (type == "Gather")
        {
            if (money >= 5000)
            {
                return true;
            }
        }
        if (type == "Social")
        {
            if (money >= 2500)
            {              
                return true;
            }
        }     
        return false;
    }
}
