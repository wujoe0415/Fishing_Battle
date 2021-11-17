using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float vetical = 0.1f;
    public float horizontal = 0.1f;
    //private bool jumpingCheck = false;
    public bool groundCheck = false;
    public int jumpforce = 1;

    [HideInInspector]
    public SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimator;
    public static bool isMessUp = false;

    new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && groundCheck)
        {
            rigidbody2D.AddForce(Vector3.up * jumpforce);
        }
        /*if (Input.GetKey(KeyCode.DownArrow))
            this.gameObject.transform.position += new Vector3(0f, -1 * vetical, 0f);*/
        if (isMessUp)
            MessUp();
        else
            Horizontal();
    }

    private void Horizontal()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x <= 8.5)
                this.gameObject.transform.position += new Vector3(horizontal, 0f, 0f);
            playerSpriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -8.5)
                this.gameObject.transform.position += new Vector3(-1 * horizontal, 0f, 0f);
            playerSpriteRenderer.flipX = true;
        }
    }

    private void MessUp()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x <= 8.5)
                this.gameObject.transform.position += new Vector3(horizontal, 0f, 0f);
            playerSpriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > -8.5)
                this.gameObject.transform.position += new Vector3(-1 * horizontal, 0f, 0f);
            playerSpriteRenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D selfbody)
    {
        if (selfbody.gameObject.tag == "ground")
        {
            groundCheck = true;
        }
    }
    void OnCollisionExit2D(Collision2D selfbodyexit)
    {
        if (selfbodyexit.gameObject.tag == "ground")
            groundCheck = false;
    }
}
