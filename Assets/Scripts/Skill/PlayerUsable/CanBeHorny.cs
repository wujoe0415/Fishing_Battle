using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeHorny : MonoBehaviour
{
    GeneralHuman Player;
    GeneralHuman Enemy;
    public int debuffAttack = 5;
    public int debuffDef = 10;
    public int recoverHp = 20;
    // Start is called before the first frame update
    void Start()
    {
        Player = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        Enemy = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        WeakenPlayerAndStrength();
        Check();
    }

    void WeakenPlayerAndStrength()
    {
        Enemy.atk -= debuffAttack;
        Enemy.def -= debuffDef;

        Player.hp += recoverHp;
    }

    void OnDisable()
    {
        Recover();
    }

    void Recover()
    {
        Enemy.atk += debuffAttack;
        Enemy.def += debuffDef;
    }

    private void Check()
    {
        if (PlayerStatus.Checkexist("CantBeHorny" + "(Clone)"))
        {
            GameObject temp;
            temp = GameObject.Find("CantBeHorny" + "(Clone)").gameObject;
            if (temp != null)
                EnemyStatus.offsetEnemySkill(temp);
        }
    }
}
