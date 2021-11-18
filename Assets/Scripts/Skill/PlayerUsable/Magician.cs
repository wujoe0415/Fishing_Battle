using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    GeneralHuman PlayerData;
    GetHurt PlayerGetHurt;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        PlayerGetHurt = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        PlayerStatus.ClearAllPlayerStatus();
        //EnemyStatus.addEnemySkill(this.gameObject);
        PlayerStatus.UnAvailSkill(this.gameObject);
        MagicianSkill();
        Check();
    }

    private void OnDisable()
    {
        Recover();
    }

    void MagicianSkill()
    {
        PlayerData.atk += 50;
        Debug.Log(PlayerData.hp - 500);
        PlayerGetHurt.SufferDamage(PlayerData.hp - 500);
    }
    void Recover()
    {
        PlayerData.atk -= 50;
        PlayerGetHurt.SufferDamage(PlayerData.hp - 500);
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
