using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float horizontal = 0.1f;
    private Animator m_animator;
    private SpriteRenderer m_spriteRenderer;
    // Start is called before the first frame update
    public Vector3 targetPosition;
    public Transform playerPosition;

    public float stayTime = 0.0f;
    public float timer = 0.0f;
    public bool isStaying = false;

    public bool isRedLeaf = false;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        //m_spriteRenderer.flipX = true;

        targetPosition = this.gameObject.transform.position;
        ChangeTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //m_animator.SetBool("Attack", false);

        if (isStaying)
            Stay();
        else
        {
            if (Mathf.Abs(targetPosition.x - gameObject.transform.position.x) < 0.5f)
            {
                ChangeTargetPosition();
            }
            else
            {
                m_animator.SetFloat("WalkSpeed", 1.0f);
                if (targetPosition.x < transform.position.x)
                {
                    this.gameObject.transform.position += new Vector3(-1 * horizontal, 0f, 0f);
                    if (isRedLeaf)
                        m_spriteRenderer.flipX = false;
                    else 
                        m_spriteRenderer.flipX = true;
                }
                else if (targetPosition.x > transform.position.x)
                {
                    this.gameObject.transform.position += new Vector3(horizontal, 0f, 0f);
                    if (isRedLeaf)
                        m_spriteRenderer.flipX = true;
                    else
                        m_spriteRenderer.flipX = false;
                }
            }
        }
    }
    void Stay()
    {
        if (timer > stayTime)
        {
            timer = 0f;
            isStaying = false;
        }

        else
        {
            m_animator.SetFloat("WalkSpeed", 0.0f);
            timer += Time.deltaTime;
        }
        
    }
    void ChangeTargetPosition()
    {
        isStaying = true;
        timer = 0f;

        stayTime = Random.Range(0.5f, 1.5f);
        targetPosition = new Vector3(Random.Range(-6,6),0,0);

        m_animator.SetFloat("WalkSpeed", 0.0f);
    }
}
