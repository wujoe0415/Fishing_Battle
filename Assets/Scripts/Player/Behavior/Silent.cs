using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Silent : MonoBehaviour
{
    public GameObject BattleArena;
    public VideoPlayer video;
    public GameObject BattleCanvas;
    public GameObject SilentCanvas;
    public AudioSource BGM;
    public GeneralHuman BigDoggie;
    public GetHurt enemyGetHurt;
    public Judge judge;
    public static bool useSilentSkill = false;
    [Range(1,400)]
    public int minHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        video = GameObject.Find("SilentWench").GetComponent<VideoPlayer>();
        BattleArena = GameObject.FindGameObjectWithTag("Battle");
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        video.enabled = false;
        judge = GameObject.Find("Judge").GetComponent<Judge>();
        BattleCanvas = GameObject.Find("BattleCanvas");
        SilentCanvas = GameObject.Find("SkillCanvas");
        enemyGetHurt = BattleInitiation.currentEnemy.GetComponent<GetHurt>();
        BigDoggie = GetComponent<GeneralHuman>();
        SilentCanvas.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if ( BigDoggie.hp < minHp && (BattleInitiation.currentEnemy.name == "RedLeaf" || BattleInitiation.currentEnemy.name == "Teacher") && BattleInitiation.currentPlayer != null )
            {
                enemyGetHurt = BattleInitiation.currentEnemy.GetComponent<GetHurt>();
                enemyGetHurt.SufferSkill(400);
                BattleArena.SetActive(false);
                BGM.Stop();
                SilentCanvas.SetActive(true);
                useSilentSkill = true;
                
                BattleCanvas.SetActive(false);
                video.enabled = true;

                Invoke("TurnOffVideo", 6.5f);
            }
        }
    }
    void TurnOffVideo()
    {
        BattleArena.SetActive(true);
        BattleCanvas.SetActive(true);
        video.Stop();
        video.enabled = false;
        SilentCanvas.SetActive(false);
        judge.JudgeWinorLose("Enemy");
    }
}
