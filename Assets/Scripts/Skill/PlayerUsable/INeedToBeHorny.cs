using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INeedToBeHorny : MonoBehaviour,CardContinue
{
    GeneralHuman Player;
    GeneralHuman Enemy;
    GetHurt EenmyHurt;

    public int buffAtk = 20;
    public int buffDef = 10;
    public int directDamage = 30;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Player = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        Enemy = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        EenmyHurt = BattleInitiation.currentEnemy.GetComponent<GetHurt>();
        Player.atk += buffAtk;
        Player.def += buffDef;

        EenmyHurt.SufferDamage(directDamage);
    }
    void Recover()
    {
        Player.atk -= buffAtk;
        Player.def -= buffDef;
    }
    public void Card()
    {
        StrengthPlayer();
    }
}
