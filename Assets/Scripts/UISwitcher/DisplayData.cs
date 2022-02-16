using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour
{
    Text text;
    public GeneralHuman data;
    // Update is called once per frame
    private void OnEnable()
    {
        text = GetComponent<Text>();
        if (this.gameObject.name == "PlayerData" && BattleInitiation.currentPlayer != null)
        {
            data = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
            ShowData();
        }
        else if (this.gameObject.name == "EnemyData" && BattleInitiation.currentEnemy != null)
        {
            data = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
            ShowData();
        }
        else
            Debug.LogWarning("DataError");

    }
    void ShowData()
    {
        text.text = data.hp + "\n\n" + data.atk + "\n\n" + data.def;
    }
    private void OnDisable()
    {
        text = null;
        data = null;
    }
    

}
