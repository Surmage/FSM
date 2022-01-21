using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update

    public void setValue(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void setCurrentValue(int health)
    {
        if(health >= 0)
        {
            slider.value = health;
        }            
    }
}
