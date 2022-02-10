using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [Range(1,10)]
    public int delayTime = 2;
    private float passTime = 0;
    void Update()
    {
        if (passTime < delayTime)
            passTime += Time.deltaTime;
        else if(passTime >= delayTime && Input.anyKey)
        {
            Debug.Log("Back to Menu Animation");
            SceneManager.LoadScene(0);
        }
    }
}
