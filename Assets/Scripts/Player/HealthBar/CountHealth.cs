using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountHealth : MonoBehaviour
{
    //public GeneralHuman get;
    public Text counting;
    private string maxHP;
    
    public void ResetHealth(int maxhealth)
    {
        maxHP = maxhealth.ToString();
        counting.text = maxhealth.ToString() + " / " + maxHP ;
    }
    public void SetHealth(int health)
    {
        counting.text = health.ToString() + " / " + maxHP;
    }
}
