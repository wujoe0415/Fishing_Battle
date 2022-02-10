using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator transmition;
    public void PlayGame()
    {
        StartCoroutine(Transmit());
    }
    IEnumerator Transmit()
    {
        transmition = GameObject.Find("TransmitionFish").GetComponent<Animator>();
        transmition.SetTrigger("FishLeave");
        yield return new WaitForSeconds(1); // 1s to complete the animation
        SceneManager.LoadScene(1);
    }
}
