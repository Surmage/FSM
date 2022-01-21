using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public int hunger;
    public int thirst;
    public string type;
    public GameObject actor;

    // Start is called before the first frame update

    public void Execute()
    {
        
    }
    public void problem()
    {

    }
    public void changeText(string output)
    {
        //Debug.Log(output);
    }
    public void setStartValues(string type)
    {
        hunger = 3000;
        thirst = 500;
        actor = GameObject.Find("Character");
        this.type = type;
    }
    public void setCurrentValues()
    {

    }
}
