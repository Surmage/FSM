using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : State
{
    // Start is called before the first frame update
    void Start()
    {
        setStartValues("Sleep");
        //changeText("Eating");
    }

    // Update is called once per frame
    void Update()
    {
        changeText("Sleeping");
        actor.GetComponent<Actor>().changeHunger(-1);
        actor.GetComponent<Actor>().changeThirst(-1);
    }
}
