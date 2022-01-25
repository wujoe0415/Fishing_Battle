using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool isPause = false;
    // Start is called before the first frame update
    private void Awake()
    {
        pauseUI.SetActive(false);
        isPause = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gamePauseOrResume();
    }
    void gamePauseOrResume()
    {
        if (Time.timeScale == 0f) // resume
        {
            Time.timeScale = 1;
            Debug.Log("Resume");
            pauseUI.SetActive(false);
            isPause = false;
            Debug.Log("PauseGame.isPause = " + PauseGame.isPause);
        }
        else if (Time.timeScale == 1.0f) // pause
        {
            Time.timeScale = 0;
            Debug.Log("Pause");
            pauseUI.SetActive(true);
            isPause = true;
            Debug.Log("PauseGame.isPause = " + PauseGame.isPause);
        }
    }
}
