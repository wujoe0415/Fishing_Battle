using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    Text name;
    public string playerName;
    private void OnEnable()
    {
        name = this.gameObject.GetComponent<Text>();
        if (GameObject.Find("GetPlayerName") != null)
            playerName = GameObject.Find("GetPlayerName").GetComponent<GetPlayerName>().GetName();
        
        if (this.gameObject.name == "PlayerName")
        {
            if (playerName == "")
                name.text = BattleInitiation.currentPlayer.name;
            else
                name.text = playerName;
        }
        else if (this.gameObject.name == "EnemyName")
            name.text = BattleInitiation.currentEnemy.name;
        else
            Debug.LogWarning("NameError");
    }

    //public void InputName(InputField input)
    //{
    //    if (input.text.Length > 0)
    //    {
    //        playerName = input.text;
    //    }
    //    else if (input.text.Length == 0)
    //    {
    //        Debug.Log("Main Input Empty");
    //    }
    //}
}
