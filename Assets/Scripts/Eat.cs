using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : State
{  
    // Start is called before the first frame update
    void Start()
    {
        setStartValues("Eat");
        //changeText("Eating");
    }

    // Update is called once per frame
    void Update()
    {
        changeText("Eating");
        actor.GetComponent<Actor>().changeHunger(1);
        actor.GetComponent<Actor>().changeThirst(1);
    }
}
