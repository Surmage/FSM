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
    GameObject messageDispatcher;
    Telegram telegram;
    GameObject state;
    // Start is called before the first frame update
    void Start()
    {
        canSocial = true;
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
        messageDispatcher = GameObject.Find("MessageDispatcher");
        int i = Random.Range(0, 4);
        telegram = messageDispatcher.GetComponent<Telegram>();
        s = telegram.changeState(i);
        s.Enter(name);
        //type = s.type;

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
            status = "Dead";
            s = telegram.changeState(status, s, this);
            s.Enter(name);
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
                    status = isAnythingLow();

                    //Check if it is okay to switch to eating
                    //Change

                    enterState();
                    return;
                }
                if (amIFine() && change > 0)
                {
                    status = isAnythingLow();

                    //Check if it is okay to stop eating

                    //busy = true;

                    enterState();

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
                    status = isAnythingLow();

                    enterState();
                    //Change                    
                    return;
                }
                if (amIFine() && change > 0)
                {
                    status = isAnythingLow();

                    //busy = true;

                    enterState();


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
                    status = isAnythingLow();

                    //busy = true;

                    enterState();


                    return;
                }
                if (amIFine() && change > 0)
                {
                    status = isAnythingLow();
                    enterState();

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
                if (money <= 1000 && change < 0)
                {
                    status = isAnythingLow();

                    //busy = true;
                    enterState();

                    return;
                }
                //Change                    
            }
            //if too high
            if (amIFine() && change > 0)
            {
                status = isAnythingLow();

                enterState();

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
                status = isAnythingLow();

                enterState();

                return;
            }
            //Change         


            //if too high
            if (amIFine() && change > 0)
            {
                status = isAnythingLow();

                enterState();


            }

        }
    }
    private void enterState()
    {
        s = telegram.GetComponent<Telegram>().changeState(status, s, this);
        s.Enter(name);
        type = s.type;       
    }
    public void enterSocial()
    {
        s = telegram.GetComponent<Telegram>().changeState(4);
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
        //string type = messager.GetComponent<StateManager>().type;
        if (s.type == "Drink")
        {
            if (thirst >= 3500)
            {
                return true;
            }
        }
        if (s.type == "Eat")
        {
            if (fullness >= 3500)
            {
                return true;
            }
        }
        if (s.type == "Sleep")
        {
            if (energy >= 4000)
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
            if (money >= 5000)
            {
                return true;
            }
        }      
        if (s.type == "Idle")
        {
            return true;
        }
        return false;
    }
    public string isAnythingLow()
    {
        List<(float, string)> arrs = new List<(float, string)>()
        {(thirst, "Thirsty"), (energy, "Sleepy"), (fullness, "Hungry"), (money, "Poor"), (happiness, "Bored") };
        List<(float, string)> arrsCopy = arrs;
        if (!canSocial)
        {
            arrs.RemoveAt(4);
        }
        arrs.Sort();
        arrsCopy.Sort();

        //arrs.Sort();
        if (arrsCopy[0].Item1 <= 1000 && arrsCopy[1].Item1 <= 1000)
        {
            fix(arrsCopy);
            return "Fine";
        }
        else if (arrs[0].Item1 <= 1000)
        {
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
                    return status;
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
                    return status;
                }
            }

        }
        //listed in order of importance
    }
    private bool fix(List<(float, string)> arr)
    {

        Debug.Log(name + " " + arr[0].Item2 + " " + arr[1].Item2 + " " + arr[2].Item2 + " ");
        string string1 = arr[0].Item2;
        string string2 = arr[1].Item2;
        string string3 = arr[2].Item2;

        //Stats increase by a lot instantly?
        if (!busy)
        {
            setBusy(6);
            enterStateDelayed(0, string1);
            enterStateDelayed(3, string2);
            enterStateDelayed(6, string3);

            //while (arr[0].Item1 <= 7000)
            //{
            //    s.Execute(name);
            //    type = s.type;
            //}

            //status = string2;
            //enterState();
            //while (arr[1].Item1 <= 7000)
            //{
            //    s.Execute(name);
            //    type = s.type;
            //}

            //status = string3;
            //enterState();
            //while (arr[2].Item1 <= 7000)
            //{
            //    s.Execute(name);
            //    type = s.type;
            //}

        }
        //thirst = 8000;
        //fullness = 8000;
        //energy = 8000;
        //money = 8000;
        //happiness = 8000;
        return busy;
    }
    public string getStatus()
    {
        return status;
    }
    public void setStatus(string status)
    {
        this.status = status;
    }
    private IEnumerator enterStateDelayed(float waitTime, string newStatus)
    {
        WaitForSeconds wait = new WaitForSeconds(waitTime / telegram.getSpeed());
        yield return wait;
        status = newStatus;
        enterState();
    }
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

    public IEnumerator setBusy(float waitTime)
    {
        if (!busy)
        {
            busy = true;
            //Debug.Log(name + " " + canSocial);

            WaitForSeconds wait = new WaitForSeconds(waitTime / telegram.getSpeed());
            yield return wait;
            busy = false;
            //Debug.Log(name + " " + canSocial);
        }
    }

}
