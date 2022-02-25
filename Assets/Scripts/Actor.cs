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
        //type = s.type;

    }

    // Update is called once per frame
    void Update()
    {
        
        s.Execute(name);
        type = s.type;
        //Debug.Log(name + " type: " + type + " status: " + status + " Can social: " + canSocial);

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
                if (fullness <= 1000 && change < 0)
                {
                    checkShouldEnter();

                    return;
                }
                if (amIFine() && change > 0)
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
                if (thirst <= 1000 && change < 0)
                {
                    checkShouldEnter();

                    //Change                    
                    return;
                }
                if (amIFine() && change > 0)
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
                if (energy <= 1000 && change < 0)
                {
                    checkShouldEnter();

                    return;
                }
                if (amIFine() && change > 0)
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
            if(status != "Social")
            {
                //if too low
                if (money < 1700 && change < 0)
                {
                    checkShouldEnter();

                    return;
                }
                //Change                    
            }
            //if too high
            if (amIFine() && change > 0)
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


                return;
            }
            //Change         


            //if too high
            if (amIFine() && change > 0)
            {
                checkShouldEnter();
            }

        }
    }
    private void checkShouldEnter()
    {
        status = isAnythingLow();
        if (!compareStatusType())
        {
            enterState();
        }
    }
    public void enterState() //not called when stuck
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
        if (s.type == "Gather")
        {
            if (money >= 5000)
            {           
                return true;
            }
        }
        if (s.type == "Mine")
        {
            if (money >= 10000)
            {
                return true;
            }
        }
        if (s.type == "Social")
        {
            if (happiness >= 7000)
            {              
                return true;
            }
        }
        //if (s.type == "Idle")
        //{
        //    if (money >= 2500 && happiness >= 7000)
        //    {
        //        return true;
        //    }
        //}
        return false;
    }
    public bool canISocial()
    {
        if(money <= 1700)
        {
            return false;
        }
        else
        {
            //string type = messager.GetComponent<StateManager>().type;
            if (s.type == "Drink")
            {
                return true;
            }
            if (s.type == "Eat")
            {
                if (fullness >= 1000)
                {
                    return true;
                }
            }
            if (s.type == "Sleep")
            {
                if (energy >= 6000)
                {
                    return true;
                }
            }
            if (s.type == "Gather")
            {
                return true;
            }
            if (s.type == "Mine")
            {
                if (money >= 5000)
                {
                    return true;
                }
            }
            if (s.type == "Idle")
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
        List<(float, string)> arrsCopy = arrs;

        if (!canSocial || money < 1000)
        {
            arrs.RemoveAt(4);
            //Debug.Log(name + " cannot be social");
        }
        if (needRepair && money < 1700)
        {
            //Debug.Log("Removed: " + arrs[3].Item2);
            arrs.RemoveAt(3);
            //Debug.Log(name + " cannot work");
        }
        else if(energy <= 100 || happiness <= 100)
        {
            arrs.RemoveAt(3);
        }
        if (arrs[2].Item1 <= 1000 && money < 200)
        {
            if(timesAskedForHelp <= 4)
            {
                if (!telegram.fix(this, arrs, arrsCopy))
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

            //Debug.Log(name + " cannot afford food");
        }
        arrs.Sort();
        arrsCopy.Sort();
        //foreach((float, string) type in arrs){
        //    Debug.Log(name + " " + type);
        //}
        if (arrs[0].Item1 <= 1000)
        {
            if(arrs[0].Item2 == "Poor")
            {
                //Debug.Log(money + " needRepair is: " + needRepair);
            }
            return arrs[0].Item2;
            
        }
        
        else
        {           
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
        //Debug.Log("Oh no");
        //listed in order of importance
    }
    
    public string getStatus()
    {
        return status;
    }
    public void setStatus(string status)
    {
        this.status = status;
    }
    private bool compareStatusType()
    {
        if (status == "Hungry")
        {
            if(type == "Eat")
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
            if (type == "Sleep")
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
            if (type == "Drink")
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
            if (type == "Gather")
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
            if (type == "Social")
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
            if (type == "Idle")
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
            if (type == "Mine")
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

    //private IEnumerator enterStateDelayed(float waitTime, string newStatus)
    //{
    //    WaitForSeconds wait = new WaitForSeconds(waitTime / telegram.getSpeed());
    //    yield return wait;
    //    status = newStatus;
    //    enterState();
    //}
    public IEnumerator setCanSocial(float waitTime)
    {
        if (canSocial)
        {
            canSocial = false;
            //Debug.Log(name + " " + canSocial);

            WaitForSeconds wait = new WaitForSeconds(waitTime / telegram.getSpeed());
            yield return wait;
            canSocial = true;
            //Debug.Log(name + " " + canSocial);
        }
    }

    //public IEnumerator setBusy(float waitTime)
    //{
    //    if (!busy)
    //    {
    //        busy = true;
    //        //Debug.Log(name + " " + canSocial);

    //        WaitForSeconds wait = new WaitForSeconds(waitTime / telegram.getSpeed());
    //        yield return wait;
    //        busy = false;
    //        //Debug.Log(name + " " + canSocial);
    //    }
    //}

}
