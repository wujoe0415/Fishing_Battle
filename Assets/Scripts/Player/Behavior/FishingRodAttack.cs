using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRodAttack : MonoBehaviour
{
    [Header("EnemyData")]
    public GameObject currentEnemy;
    private GetHurt enemyGetHurt;
    public GeneralHuman EnemyData;
    [Header("PlayerData")]
    public GeneralHuman PlayerData;

    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;

    [Header("Attack")]
    public Transform attackPoint;
    public Vector3 anotherAttackPoint;
    public float attackFrequency;
    public GameObject shield;
    private float timer = 0.0f;
    public bool canAttack = true;
    
    
    [Header("Audio Clip")]
    public AudioSource audioSource;
    public AudioClip attackClip;
    public AudioClip defendClip;
    public float volume = 0.5f;
    
    void Start()
    {
        //currentEnemy = GameObject.FindGameObjectWithTag("Enemy");
        currentEnemy = BattleInitiation.currentEnemy.gameObject;
        enemyGetHurt = currentEnemy.GetComponent<GetHurt>();
        EnemyData = currentEnemy.GetComponent<GeneralHuman>();
        PlayerData = GetComponent<GeneralHuman>();

        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.A))
            Attack();
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            Defense();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (shield.activeInHierarchy)
            {
                UnDefense();
            }
        }

        timer += Time.deltaTime;

        if (timer >= attackFrequency)
        {
            timer = 0.0f;
            canAttack = true;
        }
        
    }
    void Attack()
    {
        //Animation
        playerAnimator.SetTrigger("Attack");
        //Audio
        audioSource.PlayOneShot(attackClip, volume);

        if(isHitEnemy())
        {
            canAttack = false;
            if (RandomAttack.enemyHasShield)
            {
                enemyGetHurt.SufferDamage(PlayerData.atk - EnemyData.def);
                RandomAttack.enemyHasShield = false;
            }
            else
                enemyGetHurt.SufferDamage(PlayerData.atk - EnemyData.def);
            timer = 0.0f;
        }
    }
    private bool isHitEnemy()
    {
        if (FaceWhere.isFaceRight(this.gameObject)&&currentEnemy.transform.position.x >= transform.position.x && attackPoint.position.x > currentEnemy.transform.position.x)
            return true;
        else if (!FaceWhere.isFaceRight(this.gameObject) && currentEnemy.transform.position.x < transform.position.x && anotherAttackPoint.x < currentEnemy.transform.position.x)
            return true;
        else
            return false;
    }
    void Defense()
    {
        shield.SetActive(true);
        PlayerData.def += 5;
    }
    void UnDefense()
    {
        shield.SetActive(false);
        PlayerData.def -= 5;
    }
}
