using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralHuman : MonoBehaviour
{
    public int hp;
    public int atk;
    public int def;

    private CountHealth ch;
    private HealthBarSlide bar;
    private void Start()
    {
        if (this.gameObject.tag == "Enemy")
        {
            ch = GameObject.FindGameObjectWithTag("EnemyBarNum").GetComponent<CountHealth>();
            bar = GameObject.FindGameObjectWithTag("EnemyBar").GetComponent<HealthBarSlide>();
        }
        else if (this.gameObject.tag == "Player")
        {
            ch = GameObject.FindGameObjectWithTag("PlayBarNum").GetComponent<CountHealth>();
            bar = GameObject.FindGameObjectWithTag("PlayerBar").GetComponent<HealthBarSlide>();
        }

        ch.ResetHealth(this.hp);
        bar.MaxSetHealth(this.hp);
    }

}
