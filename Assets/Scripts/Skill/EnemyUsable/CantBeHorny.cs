using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBeHorny : MonoBehaviour
{
    GeneralHuman Player;
    GeneralHuman Enemy;
    GetHurt enemyPlus;

    private GameObject temp;

    public int debuffAtk = 5;
    public int debuffDef = 10;
    public int recoverHP = 20;
    // Start is called before the first frame update
    void Start()
    {
        enemyPlus = BattleInitiation.currentEnemy.GetComponent<GetHurt>();
        enemyPlus.RecoverHealth(recoverHP);
        Check();
    }
    void OnEnable()
    {
        WeakenPlayerAndStrength();
    }

    void WeakenPlayerAndStrength()
    {
        Player = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        Enemy = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();

        Player.atk -= debuffAtk;
        Player.def -= debuffDef;
    }

    void OnDisable()
    {
        Recover();
    }

    void Recover()
    {
        Player.atk += debuffAtk;
        Player.def += debuffDef;
    }
    private void Check()
    {
        if (EnemyStatus.Checkexist("CanBeHorny" + "(Clone)"))
        {
            temp = GameObject.Find("CanBeHorny" + "(Clone)").gameObject;
            if (temp != null)
            {
                PlayerStatus.offsetPlayerSkill(temp);
            }
        }
    }
}
