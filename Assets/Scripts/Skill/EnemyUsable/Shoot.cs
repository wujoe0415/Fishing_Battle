using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GeneralHuman EnemyData;
    public GetHurt playerSuffer;
    public int buffAttack = 50;
    public int shootDamage = 200;
    // Start is called before the first frame update
    void Start()
    {
        EnemyData = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        playerSuffer = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        BoostATK();
        Check();
    }

    private void BoostATK()
    {
        EnemyData.atk += buffAttack;
        playerSuffer.SufferDamage(shootDamage);
    }

    private void OnDisable()
    {
        Recover();
    }
    private void Check()
    {
        if (EnemyStatus.Checkexist("CanBeHorny" + "(Clone)"))
        {
            GameObject temp;
            temp = GameObject.Find("INeedToBeHorny" + "(Clone)").gameObject;
            if (temp != null)
                PlayerStatus.offsetPlayerSkill(temp);
        }
    }

    private void Recover()
    {
        EnemyData.atk -= buffAttack;
    }
}
