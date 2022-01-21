using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : State
{
    // Start is called before the first frame update
    void Start()
    {
        setStartValues("Drink");
    }

    // Update is called once per frame
    void Update()
    {
        actor.GetComponent<Actor>().changeThirst(2);
    }
}
