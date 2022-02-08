using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBubble : MonoBehaviour
{
    [Range(0.0f,10f)]
    public float attackRange = 0f;
    [Range(0.0f, 10f)]
    public float originGap = 0f;
    [Range(0.0f,1000f)]
    public float speed = 100f;
    [Range(1.0f,1.02f)]
    public float sizeGrowRate = 1.01f;
    [Range(0.0f, 5.0f)]
    public float cd = 1.0f;
    [Range(0f, 100f)]
    public float force; 

    private SpriteRenderer fishBossSprite;
    private Rigidbody2D fishBossRigid;
    bool isRelease = false;
    bool invokeFlag = false;

    private void Start()
    {
        fishBossSprite = this.gameObject.GetComponent<SpriteRenderer>();
        fishBossRigid = this.gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (RandomAttack.isAttacking && !isRelease)
        {
            Debug.Log("in Attack");
            isRelease = true;
            if (FaceWhere.isFaceRight(this.gameObject.transform.parent.gameObject))
                Attack("Right");
            else
                Attack("Left");
        }
        //else if(!RandomAttack.isAttacking && isRelease)
        //{
        //    if (FaceWhere.isFaceRight(this.gameObject.transform.parent.gameObject))
        //        StopAttack("Right");
        //    else
        //        StopAttack("Left");
        //}
        if(isRelease && !invokeFlag)
        {
            invokeFlag = true;
            Invoke("NextCD", cd); 
        }
    }
    void Attack(string dir)
    {
        if (dir == "Right")
            fishBossRigid.AddForce(transform.right * force, ForceMode2D.Impulse);
        else if(dir == "Left")
            fishBossRigid.AddForce(-1 * transform.right * force, ForceMode2D.Impulse);
    }
    void StopAttack(string dir)
    {
        Debug.Log("Stop");
        if (dir == "Right")
            this.gameObject.transform.position = this.gameObject.transform.parent.position + new Vector3(originGap, 0, 0);
        else if (dir == "Left")
            this.gameObject.transform.position = this.gameObject.transform.parent.position - new Vector3(originGap, 0, 0);
    }
    void NextCD()
    {
        isRelease = false;
        invokeFlag = false;

        if (FaceWhere.isFaceRight(this.gameObject.transform.parent.gameObject))
            StopAttack("Right");
        else
            StopAttack("Left");
    }
}
