using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHurt : MonoBehaviour
{
    public int maxHealth;
    //public static int currentHealth;
    public int currentHealth;

    public CountHealth ch;
    public HealthBarSlide bar;

    //public  bool GameOver = false;
    public GeneralHuman Self;

    private Animator sa_animator;
    private SpriteRenderer sa_spriteRenderer;

    public Judge judge;
    void Start()
    {
        judge = GameObject.Find("Judge").GetComponent<Judge>();
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
        Self = GetComponent<GeneralHuman>();
        maxHealth = Self.hp;
        currentHealth = maxHealth;
        bar.MaxSetHealth(maxHealth);

        //Animation && Audio
        sa_animator = GetComponent<Animator>();
        sa_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SufferDamage(int damage)
    {
        sa_animator.SetTrigger("SufferAttack");
        if (damage < 0) // invalid damage
            return;

        currentHealth -= damage;
        if (currentHealth < 1)
            judge.JudgeWinorLose(this.gameObject.tag);

        bar.SetHealth(currentHealth >= 0 ? currentHealth : 0);
        ch.SetHealth(currentHealth >= 0 ? currentHealth : 0);
        Self.hp = currentHealth >= 0 ? currentHealth : 0;
    }
    public void RecoverHealth(int recover)
    {
        currentHealth += recover;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        bar.SetHealth(currentHealth);
        ch.SetHealth(currentHealth);
        Self.hp = currentHealth;
    }
    public void SufferSkill(int damage)
    {
        sa_animator.SetTrigger("SufferAttack");
        currentHealth -= damage;

        bar.SetHealth(currentHealth >= 0 ? currentHealth : 0);
        ch.SetHealth(currentHealth >= 0 ? currentHealth : 0);
        Self.hp = currentHealth >= 0 ? currentHealth : 0;
    }
}

