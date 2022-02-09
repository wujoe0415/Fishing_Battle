using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    GeneralHuman PlayerData;
    GetHurt PlayerGetHurt;
    public int buffAttack = 50;
    public int buffDEF = 50;
    [Range(50,200)]
    public int sacrificeHP = 100;
    public int recoverHp = 50;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        PlayerGetHurt = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        PlayerStatus.ClearAllPlayerStatus();
        //EnemyStatus.addEnemySkill(this.gameObject);
        //PlayerStatus.UnAvailSkill(this.gameObject);
        MagicianSkill();
        Check();
    }

    private void OnDisable()
    {
        Recover();
    }

    void MagicianSkill()
    {
        PlayerData.atk += buffAttack;
        PlayerData.def += buffDEF;

        PlayerGetHurt.SufferDamage(sacrificeHP);
    }
    void Recover()
    {
        PlayerData.atk -= buffAttack;
        PlayerData.def -= buffDEF;
        PlayerGetHurt.RecoverHealth(recoverHp);
        //PlayerGetHurt.SufferDamage(PlayerData.hp - 500);
    }

    private void Check()
    {
        GameObject temp;
        if (PlayerStatus.Checkexist("Shoot" + "(Clone)"))
        {
            temp = GameObject.Find("Shoot" + "(Clone)").gameObject;
            if (temp != null)
                EnemyStatus.offsetEnemySkill(temp);
        }
    }
}
