using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverGonnaGiveUpBeingHorny : MonoBehaviour,CardContinue
{
    GeneralHuman PlayerData;
    GetHurt PlayerPlus;
    public int buffAtk = 30;
    public int buffDef = 30;
    public int recoverHp = 30;
    // Start is called before the first frame update
    void Start()
    {
        Skill();
        Check();
    }
    private void OnDisable()
    {
        Recover();
    }

    private void Skill()
    {
        PlayerData = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        PlayerPlus = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        PlayerData.def += buffDef;
        PlayerData.atk += buffAtk;

        if (PlayerData.hp < 50)
            PlayerPlus.SufferDamage(PlayerData.hp - 100);
        else
            PlayerPlus.RecoverHealth(recoverHp);
    }

    private void Check()
    {
        if (PlayerStatus.Checkexist("God" + "(Clone)"))
        {
            GameObject temp;
            temp = GameObject.Find("God" + "(Clone)").gameObject;
            if (temp != null)
                EnemyStatus.offsetEnemySkill(temp);
        }
    }

    private void Recover()
    {
        PlayerData.def -= buffDef;
        PlayerData.atk -= buffAtk;
    }
    public void Card()
    {
        Skill();
    }
}
