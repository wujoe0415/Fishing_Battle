using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    GeneralHuman EnemyData;
    GetHurt EnemyGetHurt;

    public int buffAtk = 10;
    public int buffDef = 10;
    public int recoverHp = 50;
    // Start is called before the first frame update
    void Start()
    {
        EnemyGetHurt = BattleInitiation.currentEnemy.GetComponent<GetHurt>();
        EnemyData = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        EnemyStatus.ClearAllEnemyStatus();
        //EnemyStatus.UnAvailSkill(this.gameObject);
        Check();
    }
    
    void OnDisable()
    {
        Recover();
    }

    void GodSkill()
    {
        EnemyData.def += buffDef;
        EnemyGetHurt.RecoverHealth(recoverHp);
        EnemyData.atk += buffAtk;
    }

    void Recover()
    {
        EnemyData.def -= buffDef;
        EnemyData.atk -= buffAtk;
    }
    private void Check()
    {
        GameObject temp;
        if (EnemyStatus.Checkexist("Magician" + "(Clone)"))
        {
            temp = GameObject.Find("Magician" + "(Clone)").gameObject;
            if (temp != null)
                PlayerStatus.offsetPlayerSkill(temp);
        }
    }
}
