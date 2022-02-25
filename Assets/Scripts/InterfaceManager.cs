using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshPro stateText;
    public TextMeshPro cashText;
    public TextMeshPro timeText;
    public TextMeshPro statesText;
    GameObject actor;
    GameObject messageDispatcher;
    GameObject hungerBar;
    GameObject thirstBar;
    GameObject energyBar;
    GameObject happyBar;
    float time;
    public float day;
    public float speed;
    List<GameObject> states = new List<GameObject>();
    List<GameObject> friends = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        messageDispatcher = GameObject.Find("MessageDispatcher");
        Telegram t = messageDispatcher.GetComponent<Telegram>();
        states = t.states;
        friends = t.friends;
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
        speed = 20f;
        day = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float hunger = actor.GetComponent<Actor>().fullness;
        float thirst = actor.GetComponent<Actor>().thirst;   
        float energy = actor.GetComponent<Actor>().energy;
        float happiness = actor.GetComponent<Actor>().happiness;
        cashText.text = "Cash: " + actor.GetComponent<Actor>().money.ToString("#");
        stateText.text = actor.GetComponent<Actor>().type;
        statesText.text = " Friend 1: " + friends[0].GetComponent<Actor>().type + "\nFriend 2: " + friends[1].GetComponent<Actor>().type + "\nFriend 3:"+ friends[2].GetComponent<Actor>().type;
        time += Time.deltaTime * 1440f * speed;
        clock(time);
        hungerBar.GetComponent<Health>().setCurrentValue(hunger);
        thirstBar.GetComponent<Health>().setCurrentValue(thirst);
        energyBar.GetComponent<Health>().setCurrentValue(energy);
        happyBar.GetComponent<Health>().setCurrentValue(happiness);
        
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
