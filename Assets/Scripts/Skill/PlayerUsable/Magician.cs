using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    GeneralHuman PlayerData;
    GetHurt PlayerGetHurt;
    public int buffAttack = 50;
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
        //Debug.Log(PlayerData.hp - 500);
        PlayerGetHurt.SufferDamage(PlayerData.hp / 2);
    }
    void Recover()
    {
        PlayerData.atk -= buffAttack;
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
