using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehavior : MonoBehaviour
{
    public float fullness;
    public float thirst;
    public float energy;
    public float money;
    public float happiness;
    public string type;
    public string status;
    public bool busy;
    public bool canSocial;
    public State s;
    public bool needRepair;
    private int timesAskedForHelp;
    GameObject messageDispatcher;
    Telegram telegram;
    GameObject state;
    // Start is called before the first frame update
    void Start()
    {
        timesAskedForHelp = 0;
        canSocial = true;
        busy = false;
        status = "";
        needRepair = false;
        float startValue1= Random.Range(4000, 8000);
        float startValue2 = 8000;
        float startValue3 = Random.Range(4000, 8000);
        fullness = startValue1;
        thirst = startValue1;
        energy = startValue2;
        money = startValue3;
        happiness = startValue3;
        messageDispatcher = GameObject.Find("MessageDispatcher");
        int i = Random.Range(0, 4);
        telegram = messageDispatcher.GetComponent<Telegram>();
        s = null;
        s = telegram.changeState(i, s, this);
        s.Enter(name);
        type = s.type;

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
        if (happiness <= 0)
        {
            happiness = 0;           
        }
        if (happiness > 8000)
        {
            happiness = 8000;
        }
        if (fullness <= 0)
        {
            if(status != "Dead")
            {
                Debug.Log("Died with this type: " + type + " and status: " + status);
                status = "Dead";
                s = telegram.changeState(status, s, this);
                s.Enter(name);
            }          
        }
    }
    public void changeHunger(float change)
    {      
        if (fullness >= 0 && fullness <= 8000)
        {
            fullness += change;
            if (!busy)
            {
                //If too low
                if (fullness <= 1000 && change < 0)
                {
                    checkShouldEnter();

                }
                //If too high
                else if (amIFine() && change > 0)
                {
                    checkShouldEnter();

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
                //If too low
                if (thirst <= 1000 && change < 0)
                {
                    checkShouldEnter();

                }
                //If too high
                else if (amIFine() && change > 0)
                {
                    checkShouldEnter();

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
                //If too low
                if (energy <= 1000 && change < 0)
                {
                    if(type == "socializing" && amIFine())
                    {
                        checkShouldEnter();
                    }
                    else if(type != "socializing")
                    {
                        checkShouldEnter();
                    }

                }
                //If too high
                else if (amIFine() && change > 0)
                {
                    checkShouldEnter();
                }
            }
        }
    }
    public void changeMoney(float change)
    {        
        money += change;
        if (!busy)
        {
            if (status != "Social")
            {
                //if too low
                if (money < 1700 && change < 0)
                {
                    checkShouldEnter();
                }                   
            }
            //if too high
            else if (amIFine() && change > 0)
            {
                checkShouldEnter();

            }

        }
        
    }
    public void changeHappiness(float change)
    {
        happiness += change;
        if (!busy)
        {
            //if too low
            if (happiness <= 1000 && change < 0)
            {

                checkShouldEnter();
            }
            //Change         


            //if too high
            else if (amIFine() && change > 0)
            {
                checkShouldEnter();
            }

        }
    }
    private void checkShouldEnter()
    {
        //Check if already in state
        status = isAnythingLow();
        if (!compareStatusType())
        {
            enterState();
        }
    }
    public void enterState()
    {       
        s = telegram.GetComponent<Telegram>().changeState(status, s, this);
        s.Enter(name);
        type = s.type;       
    }
    public void enterSocial()
    {
        s = telegram.GetComponent<Telegram>().changeState(4, s, this);
        s.Enter(name);
        type = s.type;
    }

    private bool amIFine()
    {
        //Check if state main stat is high enough to exit
        if(s.type == "drinking")
        {
            if(thirst >= 7000)
            {
                return true;
            }
        }
        if(s.type == "eating")
        {
            if (fullness >= 7000)
            {
                return true;
            }
        }
        if(s.type == "sleeping")
        {
            if(energy >= 7500)
            {
                return true;
            }
        }
        if (s.type == "gathering")
        {
            if (money >= 5000)
            {           
                return true;
            }
        }
        if (s.type == "mining")
        {
            if (money >= 10000)
            {
                return true;
            }
        }
        if (s.type == "socializing")
        {
            if (happiness >= 7000)
            {              
                return true;
            }
        }
        return false;
    }
    public bool canISocial()
    {
        //Check if state main stat is high enough to socialize
        if(money <= 1700)
        {
            return false;
        }
        else
        {
            if (s.type == "drinking")
            {
                return true;
            }
            if (s.type == "eating")
            {
                if (fullness >= 1000)
                {
                    return true;
                }
            }
            if (s.type == "sleeping")
            {
                if (energy >= 6000)
                {
                    return true;
                }
            }
            if (s.type == "gathering")
            {
                return true;
            }
            if (s.type == "mining")
            {
                if (money >= 5000)
                {
                    return true;
                }
            }
            if (s.type == "idling around")
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

        //Remove possibility of entering states if should be impossible

        if (!canSocial || money < 1000)
        {
            arrs.RemoveAt(4);
        }
        if (needRepair && money < 1700)
        {
            arrs.RemoveAt(3);
        }
        else if(energy <= 100 || happiness <= 100)
        {
            arrs.RemoveAt(3);
        }
        if (arrs[2].Item1 <= 1000 && money < 200)
        {
            if(timesAskedForHelp <= 4)
            {
                if (!telegram.askForMoney(this))
                {
                    arrs.RemoveAt(2);
                }
                else
                {
                    timesAskedForHelp++;
                    return "Hungry";
                }
            }
            else
            {
                arrs.RemoveAt(2);
            }
        }
        arrs.Sort();

        //Return stat that is the lowest
        if (arrs[0].Item1 <= 1000)
        {
            return arrs[0].Item2;           
        }
        
        else
        {           
            //Enter Idle or Gathering 
            float mood = Random.Range(0, 3);
            if (mood != 2)
            {
                if(status != "Motivated")
                {
                    return "Fine";
                }
                else
                {
                    return "Motivated";
                }
                
            }
            else
            {
                if(status != "Fine")
                {
                    return "Motivated";
                }
                else
                {
                    return "Fine";
                }
            }
        }
    }
    
    private bool compareStatusType()
    {
        //Checks if type fits with status
        if (status == "Hungry")
        {
            if(type == "eating")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Sleepy")
        {
            if (type == "sleeping")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Thirsty")
        {
            if (type == "drinking")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Motivated")
        {
            if (type == "gathering")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Bored")
        {
            if (type == "socializing")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Fine")
        {
            if (type == "idling around")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Poor")
        {
            if (type == "mining")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (status == "Dead")
        {
            return false;
        }
        return false;     
    }

    public IEnumerator setCanSocial(float waitTime)
    {
        //Set canSocial variable with a timer
        if (canSocial)
        {
            canSocial = false;

            WaitForSeconds wait = new WaitForSeconds(waitTime / telegram.getSpeed());
            yield return wait;
            canSocial = true;
        }
    }

}
