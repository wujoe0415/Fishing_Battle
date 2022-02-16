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
        Check();
        ShootDamage();
    }
    private void OnEnable()
    {
        BoostATK();
    }
    private void BoostATK()
    {
        EnemyData = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        EnemyData.atk += buffAttack;
    }
    private void ShootDamage()
    {
        playerSuffer = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        playerSuffer.SufferSkill(shootDamage);
    }
    private void OnDisable()
    {
        Recover();
    }
    private void Check()
    {
        if (EnemyStatus.Checkexist("INeedToBeHorny" + "(Clone)"))
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
