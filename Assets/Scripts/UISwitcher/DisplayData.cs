using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour
{
    Text text;
    GeneralHuman data;
    // Update is called once per frame
    private void OnEnable()
    {
        text = GetComponent<Text>();
        if (this.gameObject.name == "PlayerData")
            data = BattleInitiation.currentPlayer.GetComponent<GeneralHuman>();
        else if (this.gameObject.name == "EnemyData")
            data = BattleInitiation.currentEnemy.GetComponent<GeneralHuman>();
        else
            Debug.LogWarning("NameError");
    }
    void ShowData()
    {
        text.text = data.hp + "\n" + data.atk + "\n" + data.def;
    }
    private void OnDisable()
    {
        text = null;
        data = null;
    }
    

}
