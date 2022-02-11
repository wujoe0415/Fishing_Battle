using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInitiation : MonoBehaviour
{
    public List<GameObject> PlayerPrefabs;
    public List<GameObject> EnemyPrefabs;
    public Transform BattleArena;

    public static int i = 0; //index

    public static GameObject currentPlayer;
    public static GameObject currentEnemy;
    void Awake()
    {
        Initiate();
    }
    
    public static GameObject GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public static GameObject GetCurrentEnemy()
    {
        return currentEnemy;
    }

    public void Initiate(int i)
    {
        currentEnemy = Instantiate(EnemyPrefabs[i], new Vector3(6.01f, -1.4f, 0), Quaternion.identity) as GameObject;
        {
            currentEnemy.name = EnemyPrefabs[i].name;
            currentEnemy.transform.parent = BattleArena;
        }
        FishingRodAttack player = currentPlayer.GetComponent<FishingRodAttack>();
        player.currentEnemy = currentEnemy.gameObject;
        player.enemyGetHurt = currentEnemy.gameObject.GetComponent<GetHurt>();
        player.EnemyData = currentEnemy.gameObject.GetComponent<GeneralHuman>();
    }
    public void Initiate()
    {
        currentPlayer = Instantiate(PlayerPrefabs[0], new Vector3(-4.84f, -1.4f, 0), Quaternion.identity) as GameObject;
        {
            currentPlayer.name = PlayerPrefabs[0].name;
            currentPlayer.transform.parent = BattleArena;
        }
        currentEnemy = Instantiate(EnemyPrefabs[0], new Vector3(6.01f, -1.4f, 0), Quaternion.identity) as GameObject;
        {
            currentEnemy.name = EnemyPrefabs[0].name;
            currentEnemy.transform.parent = BattleArena;
        }
    }

    //void UseCard()
    //{
    //    GameObject usedCard = GameObject.Find("PlayerCardEffect");
    //    int chlidNum = usedCard.transform.childCount;
    //    if (chlidNum != 0)
    //    {
    //        for(int i = 0; i< chlidNum;i++)
    //        {
    //            if(usedCard.transform.GetChild(i).name == "Shoot(Clone)")
    //        }
    //    }
    //}
}
