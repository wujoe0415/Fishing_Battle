using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefense : MonoBehaviour
{

    public GeneralHuman Self;
    [Range(0f, 1f)]
    public float defensePersentage;
    public static bool enemyHasShield = false;
    public int normalDEF;
    public int defenseDEF;
    [Range(0f, 1f)]
    public float delayAudio = 0.05f;


    private Animator a_animator;
    private SpriteRenderer a_spriteRenderer;
    public GameObject shield;
    // Start is called before the first frame update

    [Header("Audio Clip")]
    public AudioSource audioSource;
    public AudioClip defendClip;
    [Range(0.0f, 1.0f)]
    public float volume = 0.5f;
    void Start()
    {
        a_animator = GetComponent<Animator>();
        a_spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
            }
        }
    }
    void EnemyDef()
    {
        if(FishingRodAttack.attackHitEnemy)
            Invoke("DEFDelay", delayAudio);
        shield.SetActive(true);
        Self.def = defenseDEF;
    }
    void Shielddelay()
    {
        shield.SetActive(false);
        Self.def = normalDEF;
    }
    public void DEFDelay()
    {
        //Animation
        a_animator.SetTrigger("SufferAttack");
        //Audio
        audioSource.PlayOneShot(defendClip, volume);
    }
}
