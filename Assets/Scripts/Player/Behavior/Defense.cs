using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public GeneralHuman PlayerData;
    public GameObject shield;
    public AudioClip defendClip;
    public int increaseDEF = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPause && Input.GetKeyDown(KeyCode.D))
            useDefense();
        if (!PauseGame.isPause && Input.GetKeyUp(KeyCode.D) && shield.activeInHierarchy)
            UnDefense();
    }

    void useDefense()
    {
        shield.SetActive(true);
        PlayerData.def += increaseDEF;
    }
    void UnDefense()
    {
        shield.SetActive(false);
        PlayerData.def -= increaseDEF;
    }
}
