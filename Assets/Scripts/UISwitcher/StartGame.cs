using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator transmition;
    [Range(0f, 5f)]
    public float transmitTime = 2f;
    public void PlayGame()
    {
        StartCoroutine(Transmit());
    }
    IEnumerator Transmit()
    {
        transmition = GameObject.Find("TransmitionFish").GetComponent<Animator>();
        transmition.SetTrigger("FishLeave");
        yield return new WaitForSeconds(transmitTime); // 1s to complete the animation
        SceneManager.LoadScene(1);
    }
}
