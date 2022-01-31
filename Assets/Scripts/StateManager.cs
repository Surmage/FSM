using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateManager : MonoBehaviour
{
    public TextMeshPro stateText;
    public TextMeshPro cashText;
    public TextMeshPro timeText;
    public TextMeshPro statesText;
    GameObject actor;
    GameObject hungerBar;
    GameObject thirstBar;
    GameObject energyBar;
    GameObject happyBar;
    float time;
    public float speed;
    [SerializeField] public List<GameObject> states = new List<GameObject>();
    [SerializeField] public List<GameObject> friends = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        hungerBar = GameObject.Find("Hunger");
        thirstBar = GameObject.Find("Thirst");
        energyBar = GameObject.Find("Energy");
        happyBar = GameObject.Find("Happy");
        actor = GameObject.Find("Character");
        //state = Instantiate(states[3]);   
        hungerBar.GetComponent<Health>().setValue(8000);
        thirstBar.GetComponent<Health>().setValue(8000);
        energyBar.GetComponent<Health>().setValue(8000);
        happyBar.GetComponent<Health>().setValue(8000);
        time = 0;
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float hunger = actor.GetComponent<Actor>().hunger;
        float thirst = actor.GetComponent<Actor>().thirst;   
        float energy = actor.GetComponent<Actor>().energy;
        float happiness = actor.GetComponent<Actor>().happiness;
        cashText.text = "Cash: " + actor.GetComponent<Actor>().money.ToString();
        stateText.text = actor.GetComponent<Actor>().type;
        statesText.text = " Friend 1: " + friends[0].GetComponent<Actor>().type + "\nFriend 2: " + friends[1].GetComponent<Actor>().type + "\nFriend 3:"+ friends[2].GetComponent<Actor>().type;
        time += Time.deltaTime * 1440f * speed;
        clock(time);
        hungerBar.GetComponent<Health>().setCurrentValue(hunger);
        thirstBar.GetComponent<Health>().setCurrentValue(thirst);
        energyBar.GetComponent<Health>().setCurrentValue(energy);
        happyBar.GetComponent<Health>().setCurrentValue(happiness);

        
    }
    public State createTransition(string cause, State s)
    {
        s.Exit(cause);
        s = states[5].GetComponent<Transition>();                   
        return s;
    }
    public State changeState(string cause, State s)
    {
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
        if (cause == "Poor")
        {
            s = states[3].GetComponent<Gather>();
        }
        if (cause == "Social")
        {
            s = states[4].GetComponent<Social>();
        }
        if (cause == "Dead")
        {
            s = states[5].GetComponent<Dead>();
        }
        return s;
    }
    public State changeState(int i, State s)
    {
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


    public void clock(float time)
    {
        //time = time * 1440f;
        float day = time / 86400f;
        //3600 seconds is an hour
        float hours = time / 3600; //works
        //24 hours in a day, 60 minutes per, 60 seconds per, 
        //86 400 seconds in a day
        //1440 
        int roundedDay = (int)day;
        if (day >= 1)
        {
            hours = hours - 24 * roundedDay;
        }
        timeText.text = "Day: " + (roundedDay+1).ToString() + " Hour: " + hours.ToString("#");
    }
}
