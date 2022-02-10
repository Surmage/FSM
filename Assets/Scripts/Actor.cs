using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public float fullness;
    public float thirst;
    public float energy;
    public float money;
    public float happiness;
    public string type;
    public string status;
    public bool busy;
    State s;    
    public GameObject messager;
    GameObject state;
    // Start is called before the first frame update
    void Start()
    {
        busy = false;
        status = "";
        float startValue1= Random.Range(4000, 8000);
        float startValue2 = Random.Range(4000, 8000);
        float startValue3 = Random.Range(4000, 8000);
        fullness = startValue1;
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
        if (fullness < 0)
        {
            fullness = 0;
        }
        if (fullness > 8000)
        {
            fullness = 8000;
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
        if (fullness <= 0 && thirst <= 0)
        {
            s = messager.GetComponent<StateManager>().changeState(status, s, name);
            s.Enter(name);
            s.setNextState("Dead");
        }
    }
    public void changeHunger(float change)
    {      
        if (fullness >= 0 && fullness <= 8000)
        {
            fullness += change;
            if (!busy)
            {
                if (fullness <= 100)
                {
                    status = isAnythingLow();

                    //Check if it is okay to switch to eating
                    //Change

                    if (status == "Fine")
                    {
                        status = "Social";
                    }
                    s = messager.GetComponent<StateManager>().changeState(status, s, name);
                    s.Enter(name);
                    s.setNextState(status);
                    //StartCoroutine(wait(1));
                    
                    return;
                }
                if (amIFine())
                {
                    status = isAnythingLow();

                    //Check if it is okay to stop eating

                    if (status == "Fine")
                    {
                        status = "Social";
                    }
                    //busy = true;

                    s = messager.GetComponent<StateManager>().changeState(status, s, name);
                    s.Enter(name);
                    s.setNextState(status);
                    //StartCoroutine(wait(1));

                    
                }
            }         
        }
    }
    public void changeThirst(float change)
    {     
        if (thirst >= 0 && thirst <= 8000)
        {
            thirst += change;
            if (!busy)
            {
                if (thirst <= 1000)
                {
                    status = isAnythingLow();

                    if (status == "Fine")
                    {
                        status = "Social";
                    }
                    s = messager.GetComponent<StateManager>().changeState(status, s, name);
                    s.Enter(name);
                    s.setNextState(status);
                    //StartCoroutine(wait(1));

   
                    //Change                    
                    return;
                }
                if (amIFine())
                {
                    status = isAnythingLow();

                    if (status == "Fine")
                    {
                        status = "Social";
                    }
                    //busy = true;

                    s = messager.GetComponent<StateManager>().changeState(status, s, name);
                    s.Enter(name);
                    s.setNextState(status);
                    //StartCoroutine(wait(1));


                    
                }
            }
        }      
    }
    public void changeEnergy(float change)
    {       
        if (energy >= 0 && energy <= 8000)
        {
            energy += change;
            if (!busy)
            {        
                if (energy <= 500)
                {
                    status = isAnythingLow();

                    if (status == "Fine")
                    {
                        status = "Social";
                    }
                    //busy = true;

                    s = messager.GetComponent<StateManager>().changeState(status, s, name);
                    s.Enter(name);
                    s.setNextState(status);
                    //StartCoroutine(wait(1));

                    

                    return;
                }
                if (amIFine())
                {
                    status = isAnythingLow();

                    if (status == "Fine")
                    {
                        status = "Social";
                    }
                    s = messager.GetComponent<StateManager>().changeState(status, s, name);
                    s.Enter(name);
                    s.setNextState(status);
                    //StartCoroutine(wait(1));

                    
                }
            }
        }
    }
    public void changeMoney(float change)
    {        
        money += change;
        if (!busy)
        {
            //if too low
            if (money <= 500)
            {
                status = isAnythingLow();

                if (status == "Fine")
                {
                    status = "Social";
                }
                //busy = true;
                s = messager.GetComponent<StateManager>().changeState(status, s, name);
                s.Enter(name);
                s.setNextState(status);
                //StartCoroutine(wait(1));

                
                return;
            }
            //Change         
           
            
            //if too high
            if (amIFine())
            {
                status = isAnythingLow();

                if (status == "Fine")
                {
                    status = "Social";
                }
                s = messager.GetComponent<StateManager>().changeState(status, s, name);
                s.Enter(name);
                s.setNextState(status);
                //StartCoroutine(wait(1));

                
            }
            
        }
        
    }
    public void changeHappiness(float change)
    {
        happiness += change;
        if (!busy)
        {
            //if too low
            if (happiness <= 500)
            {
                status = isAnythingLow();

                if (status == "Fine")
                {
                    status = "Social";
                }
                //busy = true;
                //s = messager.GetComponent<StateManager>().changeState(status, s, name);
                //s.Enter(name);
                //s.setNextState(status);
                //StartCoroutine(wait(1));


                return;
            }
            //Change         


            //if too high
            if (amIFine())
            {
                status = isAnythingLow();

                if (status == "Fine")
                {
                    status = "Social";
                }
                //s = messager.GetComponent<StateManager>().changeState(status, s, name);
                //s.Enter(name);
                //s.setNextState(status);
                //StartCoroutine(wait(1));


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
        if(s.type == "Drink")
        {
            if(thirst >= 7000)
            {
                return true;
            }
        }
        if(s.type == "Eat")
        {
            if (fullness >= 7000)
            {
                return true;
            }
        }
        if(s.type == "Sleep")
        {
            if(energy >= 7500)
            {
                return true;
            }
        }
        if (s.type == "Work")
        {
            if (money >= 5000)
            {           
                return true;
            }
        }
        if (s.type == "Social")
        {
            if (money >= 2500)
            {              
                return true;
            }
        }
        if (s.type == "Idle")
        {
            if (money >= 2500 && happiness >= 2500)
            {
                return true;
            }
        }
        return false;
    }
    public string isAnythingLow()
    {
        List<(float, string)> arrs = new List<(float, string)>() 
        {(thirst, "Thirsty"), (energy, "Sleepy"), (fullness, "Hungry"), (money, "Poor"), (happiness, "Bored") };
        arrs.Sort();
        //arrs.Sort();
        for(int i=0; i<5; i++)
        {
            if(arrs[i].Item1 <= 1000)
            {
                return arrs[i].Item2;
            }
        }
        
        return "Fine";
        
        //listed in order of importance
    }
    private IEnumerator wait(float waitTime)
    {
        WaitForSeconds wait = new WaitForSeconds(waitTime);
        yield return wait;
        Debug.Log("Works");
        busy = false;
    }
}
