using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider sli;

    public void setMaxMana(float mana)
    {
        sli.value = mana;
        sli.maxValue = mana;
    }

    public void setMana(float mana)
    {
        sli.value = mana;
    }
}
