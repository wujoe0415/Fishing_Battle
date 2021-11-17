using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeHorny : MonoBehaviour
{
    GeneralHuman Player;
    GeneralHuman Enemy;
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
        Enemy.atk -= 5;
        Enemy.def -= 10;

        Player.hp += 20;
    }

    void OnDisable()
    {
        Recover();
    }

    void Recover()
    {
        Enemy.atk += 5;
        Enemy.def += 10;
    }

    private void Check()
    {
        GameObject temp;
        temp = GameObject.Find("CantBeHorny" + "(Clone)").gameObject;
        if (temp != null)
            PlayerStatus.offsetPlayerSkill(temp);
    }
}
