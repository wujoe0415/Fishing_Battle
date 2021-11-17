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
    public GameObject enemy;
    public GetHurt enemyGetHurt;
    public Judge judge;
    public static bool useSilentSkill = false;
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
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyGetHurt = GameObject.FindGameObjectWithTag("Enemy").GetComponent<GetHurt>();
        BigDoggie = GetComponent<GeneralHuman>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if ((enemy.name == "RedLeaf" || enemy.name == "Teacher") && GameObject.FindGameObjectWithTag("Player") != null && BigDoggie.hp < 100 )
            {
                BattleArena.SetActive(false);
                BGM.Stop();
                useSilentSkill = true;
                enemyGetHurt.SufferSkill(100);
                
                BattleCanvas.SetActive(false);
                video.enabled = true;

                Invoke("TurnOffVideo", 6.5f);
            }
        }
    }
    void TurnOffVideo()
    {
        BattleArena.SetActive(true);
        video.Stop();
        video.enabled = false;
        BattleCanvas.SetActive(true);
        judge.JudgeWinorLose("Enemy");
    }
}
