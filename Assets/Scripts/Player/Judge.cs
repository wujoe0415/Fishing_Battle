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
    public float blankTime = 5f;
    void Start()
    {
        battle = GameObject.FindGameObjectWithTag("Battle");
    }
    // Update is called once per frame
    
    public void JudgeWinorLose(string tag)
    {
        Destroy(battle.transform.GetChild(1).gameObject);
        if(BattleInitiation.i == 5)
            Destroy(battle.transform.GetChild(0).gameObject);
        bgm.Stop();

        if (tag == "Player") //lose
        {
            Destroy(battle.transform.GetChild(0).gameObject);
            lose.SetActive(true);
            //GameOver
        }
        else if (BattleInitiation.i == 5 && tag == "Enemy") // win
        {
            //true win
            win.SetActive(true);
            Invoke("TurnOffWinLoseAudio", blankTime);
        }
        else if (tag == "Enemy") // win
        {
            //temp win
            win.SetActive(true);
            Invoke("TurnOffWinLoseAudio", blankTime);
        }
        
    }
    private void TurnOffWinLoseAudio()
    {
        lose.SetActive(false);
        win.SetActive(false);

        //Initiate Nect Fight
        indexFight++;
        if(indexFight == 6)
        {
            //GameOver
        }
        init.Initiate(indexFight);
        bgm.Play();
    }
    
}
