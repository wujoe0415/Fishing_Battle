using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : MonoBehaviour
{
    GeneralHuman fishData;
    private IEnumerator coroutine;
    private SpriteRenderer m_spriteRenderer;
    GetHurt playerSuffer;

    AudioSource audioSource;
    [Header("Audio")]
    public AudioClip collisionSound;
    [Range(0.0f,1.0f)]
    public float volume = 0.5f;

    Wander wander;
    int maxHp = 0;
    Vector3 originPoaition = new Vector3(0, 0, 0);

    public float leftX = 0;
    public float rightX = 0;
    bool canRush = true;
    bool finishToLeft = false;
    bool finishToRight = false;
    bool finishSkill = false;
    [Range(0,1000)]
    public int speed = 600;
    [Range(10f,15f)]
    public float skillCD = 0;
    // Start is called before the first frame update
    [Range(10,50)]
    public int rushDamage = 20;
    void Start()
    {
        wander = this.gameObject.GetComponent<Wander>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        fishData = this.gameObject.GetComponent<GeneralHuman>();
        playerSuffer = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        maxHp = fishData.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRush && maxHp * 2 > fishData.hp * 3) // current hp lower than 2/3 * maxHp
            Skill();
        if (finishSkill && !canRush)
        {
            Invoke("CDset", skillCD);
            finishSkill = false;
            wander.enabled = true;
        }
    }

    void Skill()
    {
        wander.enabled = false;
        originPoaition = this.gameObject.transform.position;
        canRush = false;
        finishToLeft = false;
        finishToRight = false;
        finishSkill = false;
        coroutine = RushSkill();
        StartCoroutine(coroutine);
    }
    IEnumerator RushSkill()
    {
        while (true)
        {
            if (!finishToLeft)
                RushToLeft();
            else if (finishToLeft && !finishToRight)
                RushToRight();
            else if (finishToLeft && finishToRight)
                returnToOrigin();
            yield return null;
        }
    }
    void RushToLeft()
    {
        if (m_spriteRenderer.flipX)
            m_spriteRenderer.flipX = false;
        if (this.gameObject.transform.position.x < leftX)
        {
            finishToLeft = true;
            m_spriteRenderer.flipX = true;
            return;
        }
        
        this.gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void RushToRight()
    {
        if (this.gameObject.transform.position.x > rightX)
        {
            finishToRight = true;
            m_spriteRenderer.flipX = false;
            return;
        }
        
        this.gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
    }
    void returnToOrigin()
    {
        if(originPoaition.x > this.gameObject.transform.position.x)
        {
            StopCoroutine(coroutine); // skill cd
            finishSkill = true;
            return;
        }
        
        this.gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void CDset()
    {
        Debug.Log("canRush!");
        canRush = true;
        skillCD = Random.Range(12f, 20f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !wander.enabled)
        {
            audioSource.PlayOneShot(collisionSound, volume);
            playerSuffer.SufferDamage(rushDamage);
        }
    }
}
