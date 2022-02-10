using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Animator transmition;

    [Range(1,10)]
    public int delayTime = 2;
    private float passTime = 0;
    void Update()
    {
        if (passTime < delayTime)
            passTime += Time.deltaTime;
        else if(passTime >= delayTime && Input.anyKey)
        {
            StartCoroutine(Transmit());
        }
    }

    IEnumerator Transmit()
    {
        transmition = GameObject.Find("TransmitionFish").GetComponent<Animator>();
        transmition.SetTrigger("FishLeave");
        yield return new WaitForSeconds(1); // 1s to complete the animation
        SceneManager.LoadScene(0);
    }
}
