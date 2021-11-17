using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField]
    public GameObject battle;
    public GameObject win;
    public GameObject lose;
    public AudioSource bgm;
    public BattleInitiation init;
    private int indexFight = 0;

    void Start()
    {
        battle = GameObject.FindGameObjectWithTag("Battle");
    }
    // Update is called once per frame
    
    public void JudgeWinorLose(string tag)
    {
        Destroy(battle.transform.GetChild(1).gameObject);
        Destroy(battle.transform.GetChild(0).gameObject);
        bgm.Stop();

        if (tag == "Player") //lose
        {
            lose.SetActive(true);
            //GameOver
        }
        if (tag == "Enemy") // win
        {
            win.SetActive(true);
            Invoke("TurnOffWinLoseAudio", 5);
        }
        
    }
    private void TurnOffWinLoseAudio()
    {
        lose.SetActive(false);
        win.SetActive(false);

        //Initiate Nect Fight
        indexFight++;
        if(indexFight == 5)
        {
            //GameOver
        }
        init.Initiate(indexFight);
        bgm.Play();
    }
    
}
