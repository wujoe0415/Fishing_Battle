using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverGonnaGiveUpBeingHorny : MonoBehaviour
{
    GeneralHuman PlayerData;
    GetHurt PlayerPlus;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        PlayerPlus = BattleInitiation.currentPlayer.GetComponent<GetHurt>();
        Skill();
        Check();
    }
    private void OnDisable()
    {
        Recover();
    }

    private void Skill()
    {
        if (PlayerData.hp < 50)
            PlayerPlus.SufferDamage(PlayerData.hp - 100);

        PlayerData.def += 30;
        PlayerData.atk += 30;
        PlayerData.hp += 30;
    }

    private void Check()
    {
        GameObject temp;
        temp = GameObject.Find("God" + "(Clone)").gameObject;
        if (temp != null)
            PlayerStatus.offsetPlayerSkill(temp);
    }

    private void Recover()
    {
        PlayerData.def -= 30;
        PlayerData.atk -= 30;
    }
}
