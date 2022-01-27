using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBubble : MonoBehaviour
{
    [Range(0.0f,10f)]
    public float attackRange = 0f;
    [Range(0.0f, 10f)]
    public float originGap = 0f;
    [Range(0.0f,1f)]
    public float speed = 100f;
    [Range(1.0f,1.02f)]
    public float sizeGrowRate = 1.01f;
    [Range(0.0f, 5.0f)]
    public float cd = 1.0f;
    private float deltaX = 0f;
    
    IEnumerator coroutine;
    bool isRelease = false;
    bool invokeFlag = false;
    
    // Update is called once per frame
    void Update()
    {
        if (RandomAttack.isAttacking && !isRelease)
        {
            Debug.Log("in Attack");
            isRelease = true;
            if (FaceWhere.isFaceRight(this.gameObject.transform.parent.gameObject))
                coroutine = Attack("Right");
            else
                coroutine = Attack("Left");

            StartCoroutine(coroutine);
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
    IEnumerator Attack(string dir)
    {
        
        if (dir == "Right")
        {
            while (deltaX < attackRange)
            {
                deltaX += Time.deltaTime * speed;
                this.gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
                if (this.gameObject.transform.localScale.x < 1)
                    this.gameObject.transform.localScale *= sizeGrowRate;
                Debug.Log("attack Right " + this.gameObject.transform.position);
                yield return null;
            }
        }
        else if(dir == "Left")
        {
            while (deltaX < attackRange)
            {
                deltaX += Time.deltaTime * speed;
                this.gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
                if (this.gameObject.transform.localScale.x < 1)
                    this.gameObject.transform.localScale *= sizeGrowRate;
                Debug.Log("attack Left "+ this.gameObject.transform.position);
                yield return null;
            }
        }
        yield return null;
    }
    void StopAttack(string dir)
    {
        Debug.Log("Stop");
        deltaX = 0f;
        if (coroutine != null)
            StopCoroutine(coroutine);
        if (dir == "Right")
            this.gameObject.transform.position = this.gameObject.transform.parent.position + new Vector3(originGap, 0, 0);
        else if (dir == "Left")
            this.gameObject.transform.position = this.gameObject.transform.parent.position - new Vector3(originGap, 0, 0);
        this.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        
    }

    void NextCD()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        this.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        isRelease = false;
        invokeFlag = false;

        if (FaceWhere.isFaceRight(this.gameObject.transform.parent.gameObject))
            StopAttack("Right");
        else
            StopAttack("Left");
    }
}
