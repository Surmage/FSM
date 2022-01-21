using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State s;
    [SerializeField] private List<GameObject> states = new List<GameObject>();
    GameObject state;
    GameObject actor;
    GameObject hungerBar;
    GameObject thirstBar;
    public string type;


    // Start is called before the first frame update
    void Start()
    {
        hungerBar = GameObject.Find("Hunger");
        thirstBar = GameObject.Find("Thirst");
        actor = GameObject.Find("Character");      
        state = Instantiate(states[1]);
        s = state.GetComponent<Sleep>();
        hungerBar.GetComponent<Health>().setValue(3000);
        thirstBar.GetComponent<Health>().setValue(500);
    }

    // Update is called once per frame
    void Update()
    {
        int hunger = actor.GetComponent<Actor>().hunger;
        int thirst = actor.GetComponent<Actor>().thirst;      
        type = s.type;
        hungerBar.GetComponent<Health>().setCurrentValue(hunger);
        thirstBar.GetComponent<Health>().setCurrentValue(thirst);

        if (hunger <= 0 && thirst <= 0)
        {
            Debug.Log("Dead");
        }
    }
    public void changeState(string cause)
    {
        if(cause == "Hungry")
        {
            Destroy(state);
            state = Instantiate(states[0]);
            s = state.GetComponent<Eat>();
        }
        if (cause == "Sleepy")
        {
            Destroy(state);
            state = Instantiate(states[1]);
            s = state.GetComponent<Sleep>();
        }
        if (cause == "Thirsty")
        {
            Destroy(state);
            state = Instantiate(states[2]);
            s = state.GetComponent<Drink>();
        }
        if (cause == "Poor")
        {
            Destroy(state);
            state = Instantiate(states[3]);
            s = state.GetComponent<Gather>();
        }

    }
}
