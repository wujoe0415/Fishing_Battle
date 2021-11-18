using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INeedToBeHorny : MonoBehaviour
{
    GeneralHuman Player;
    GeneralHuman Enemy;
    GetHurt EenmyHurt;
    // Start is called before the first frame update
    void Start()
    {
        Player = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        Enemy = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        EenmyHurt = BattleInitiation.currentEnemy.GetComponent<GetHurt>();
        StrengthPlayer();
        Check();
    }
    void OnDisable()
    {
        Recover();
    }
    private void Check()
    {
        if (PlayerStatus.Checkexist("MessUpDirection" + "(Clone)"))
        {
            GameObject temp;
            temp = GameObject.Find("MessUpDirection" + "(Clone)");
            if (temp != null)
                EnemyStatus.offsetEnemySkill(temp);
        }
    }

    void StrengthPlayer()
    {
        Player.atk += 20;
        Player.def += 10;

        EenmyHurt.SufferDamage(30);
    }
    void Recover()
    {
        Player.atk -= 20;
        Player.def -= 10;
    }
}
