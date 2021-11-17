using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttack : MonoBehaviour
{
    [Header("EnemyData")]
    public float defensePersentage;
    public float attackCycle = 1.0f;
    public float maxTimeGap;
    public GetHurt playerSuffer;
    public GeneralHuman Self;
    public GeneralHuman Player;
    private float timer = 0;
    private bool canAttack = true;
    private GameObject PlayerData;
    
    [Header("Detect suffering")]
    public Transform attackPoint;
    public Vector3 rightAttackpoint;
    public Transform playerPosition;
    public static bool enemyHasShield = false;
    /* public float attackRange = 1.0f;
     public LayerMask playerLayer;*/
     
    private Animator a_animator;
    private SpriteRenderer a_spriteRenderer;
    public GameObject shield;
    
    [Header("Audio Clip")]
    public AudioSource audioSource;
    public AudioClip attackClip;
    public float attackTime;
    public AudioClip defendClip;
    [Range(0.0f,1.0f)]
    public float volume = 0.5f;
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("Player");
        playerSuffer = PlayerData.GetComponent<GetHurt>();
        Player = PlayerData.GetComponent<GeneralHuman>();
        playerPosition = PlayerData.GetComponent<Transform>();

        a_animator = GetComponent<Animator>();
        a_spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        //a_spriteRenderer.flipX = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Random.Range(0f, 1f) < defensePersentage)
            {
                EnemyDef();
                enemyHasShield = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (shield.activeInHierarchy)
            {
                Invoke("Shielddelay", 0.5f);
                Self.def /= 2;
            }
        }
        if (timer >= attackCycle)
        {
            if(canAttack && Self.hp > 0)
                EnemyAttack();
        }
        else
            timer += Time.deltaTime;

    }
    
    void EnemyAttack()
    {
        //Animation
        a_animator.SetTrigger("Attack");
        //Audio
        audioSource.Play();
        Invoke("Delay", attackTime + 0.1f);

        if (ishitPlayer())
        {
            canAttack = false;
            playerSuffer.SufferDamage(Self.atk - Player.def);
            // Recovery
            attackCycle = Random.Range(0.0f, maxTimeGap);
            timer = 0f;
        }
        
        
    }
    private bool ishitPlayer()
    {
        if (!FaceWhere.isFaceRight(this.gameObject) && playerPosition.position.x <= transform.position.x && attackPoint.position.x < playerPosition.position.x /*&& a_spriteRenderer.flipX == false*/)
            return true;
        else if (FaceWhere.isFaceRight(this.gameObject) && playerPosition.position.x >= transform.position.x && rightAttackpoint.x > playerPosition.position.x/* && a_spriteRenderer.flipX == true */)
            return true;
        else
            return false;
    }
    void EnemyDef()
    {
        Invoke("DEFDelay", 0.2f);
        shield.SetActive(true);
        Self.def *= 2;
        //Recovery
    }
    void Shielddelay()
    {
        shield.SetActive(false);
    }

    void DEFDelay()
    {
        //Animation
        a_animator.SetTrigger("SufferAttack");
        //Audio
        audioSource.PlayOneShot(defendClip, volume);
    }
    void Delay()
    {
        canAttack = true;
    }
}
