using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttack : MonoBehaviour
{
    [Header("EnemyData")]
    public float attackCycle = 1.0f;
    public float maxTimeGap;
    public GetHurt playerSuffer;
    public GeneralHuman Self;
    public GeneralHuman Player;
    private float timer = 0;
    private bool canAttack = true;
    private GameObject PlayerData;
    
    [Header("Detect suffering")]
    public Transform attackPointL;
    public Transform attackPointR;
    public Transform playerPosition;
    public static bool isAttacking = false;
    public float attackFrame;
    /* public float attackRange = 1.0f;
     public LayerMask playerLayer;*/
     
    private Animator a_animator;
    private SpriteRenderer a_spriteRenderer;
    public GameObject shield;
    
    [Header("Audio Clip")]
    public AudioSource audioSource;
    public AudioClip attackClip;
    [Range(0.0f,1.0f)]
    public float volume = 0.5f;
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("Player");
        playerSuffer = PlayerData.GetComponent<GetHurt>();
        Player = PlayerData.GetComponent<GeneralHuman>();
        Self = GetComponent<GeneralHuman>();
        playerPosition = PlayerData.GetComponent<Transform>();

        a_animator = GetComponent<Animator>();
        a_spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        //a_spriteRenderer.flipX = true;
    }
    void Update()
    {
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
        //Debug.Log("attacking");
        //Animation
        a_animator.SetTrigger("Attack");
        //Audio
        audioSource.Play();
        canAttack = false;
        isAttacking = true;
        Invoke("Delay", waitForFrame(attackFrame));

        if (ishitPlayer())
        {
            playerSuffer.SufferDamage(Self.atk - Player.def);
            // Recovery
            attackCycle = Random.Range(0.5f, maxTimeGap);
        }
        timer = 0f;
        
    }
    private bool ishitPlayer()
    {
        Debug.Log("attackPointL.position.x : " + attackPointL.position.x);
        Debug.Log("attackPointR.position.x : " + attackPointR.position.x);

        if (!FaceWhere.isFaceRight(this.gameObject) && playerPosition.position.x <= transform.position.x && attackPointL.position.x < playerPosition.position.x /*&& a_spriteRenderer.flipX == false*/)
            return true;
        else if (FaceWhere.isFaceRight(this.gameObject) && playerPosition.position.x >= transform.position.x && attackPointR.position.x > playerPosition.position.x/* && a_spriteRenderer.flipX == true */)
            return true;
        
        else
            return false;
    }
    //Recovery
    void Delay()
    {
        canAttack = true;
        isAttacking = false;
    }
    private float waitForFrame(float frame)
    {
        return frame / 0.6f;
    }
}
