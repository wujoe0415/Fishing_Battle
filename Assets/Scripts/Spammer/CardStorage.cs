using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStorage : MonoBehaviour
{
    public static void ClearUsedCard()
    {
        if (GameObject.Find("PlayerCardEffect").transform == null)
        {
            Debug.LogWarning("Cant find the PlayerCardEffect");
            return;
        }
        Transform playerCardEffect = GameObject.Find("PlayerCardEffect").transform;
        int childNum = playerCardEffect.childCount;
        for (int i = 0; i < childNum; i++)
            playerCardEffect.GetChild(i).gameObject.SetActive(false);
    }

    public static void SpawnUsedCard()
    {
        if (GameObject.Find("PlayerCardEffect").transform == null)
        {
            Debug.LogWarning("Cant find the PlayerCardEffect");
            return;
        }
        Transform playerCardEffect = GameObject.Find("PlayerCardEffect").transform;
        int childNum = playerCardEffect.childCount;

        for (int i = 0; i < childNum; i++)
            playerCardEffect.GetChild(i).gameObject.SetActive(true);
    }
}
