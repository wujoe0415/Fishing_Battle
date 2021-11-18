using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : MonoBehaviour
{
    GeneralHuman EnemyData;
    GetHurt EnemyGetHurt;
    // Start is called before the first frame update
    void Start()
    {
        EnemyGetHurt = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        EnemyData = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        EnemyStatus.ClearAllEnemyStatus();
        EnemyStatus.UnAvailSkill(this.gameObject);
        Check();
    }
    
    void OnDisable()
    {
        Recover();
    }

    void GodSkill()
    {
        EnemyData.def += 10;
        EnemyGetHurt.SufferDamage(-50);
        EnemyData.atk += 10;
    }

    void Recover()
    {
        EnemyData.def -= 10;
        EnemyData.atk -= 10;
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
