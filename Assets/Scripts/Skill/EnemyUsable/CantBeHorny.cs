using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBeHorny : MonoBehaviour
{
    GeneralHuman Player;
    GeneralHuman Enemy;

    public GameObject temp;
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
        Player.atk -= 5;
        Player.def -= 10;

        Enemy.hp += 20;
    }

    void OnDisable()
    {
        Recover();
    }

    void Recover()
    {
        Player.atk += 5;
        Player.def += 10;
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
