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
        Initiate(0);
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
        currentPlayer = Instantiate(PlayerPrefabs[i], new Vector3(-4.84f, -1.4f, 0), Quaternion.identity) as GameObject;
        {
            currentPlayer.name = PlayerPrefabs[i].name;
            currentPlayer.transform.parent = BattleArena;
        }

        currentEnemy = Instantiate(EnemyPrefabs[i], new Vector3(6.01f, -1.4f, 0), Quaternion.identity) as GameObject;
        {
            currentEnemy.name = EnemyPrefabs[i].name;
            currentEnemy.transform.parent = BattleArena;
        }
    }
    
}
