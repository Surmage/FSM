using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : State
{
    // Start is called before the first frame update
    void Start()
    {
        setStartValues("Work");
    }

    // Update is called once per frame
    void Update()
    {
        actor.GetComponent<Actor>().changeHunger(-2);
        actor.GetComponent<Actor>().changeThirst(-2);
    }
}
