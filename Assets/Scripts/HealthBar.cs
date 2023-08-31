using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sli;

    public void setMaxHealth(int health)
    {
        sli.value = health;
        sli.maxValue = health;
    }

    public void setHealth(int health)
    {
        sli.value = health;
    }
}
