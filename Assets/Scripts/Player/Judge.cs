using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Judge : MonoBehaviour
{
    [SerializeField]
    public GameObject battle;
    public GameObject win;
    public AudioSource bgm;
    public BattleInitiation init;
    private int indexFight = 0;
    public float blankTime = 5f;

    public Animator transmition;
    [Range(0f, 5f)]
    public float transmitTime = 2f;

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
            StartCoroutine(Transmit(3));
            // Lose
        }
        else if (BattleInitiation.i == 5 && tag == "Enemy") // win
        {
            //true win
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
        win.SetActive(false);

        //Initiate Nect Fight
        indexFight++;
        if(indexFight == 6)
        {
            StartCoroutine(Transmit(2));
            // Victory
        }
        init.Initiate(indexFight);
        bgm.Play();
    }

    IEnumerator Transmit(int nextScene)
    {
        transmition = GameObject.Find("TransmitionFish").GetComponent<Animator>();
        transmition.SetTrigger("FishLeave");
        yield return new WaitForSeconds(transmitTime); // 1s to complete the animation
        SceneManager.LoadScene(nextScene);
    }
}
