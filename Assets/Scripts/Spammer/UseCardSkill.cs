using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardSkill : MonoBehaviour
{

    public List<GameObject> usableCardsSamples = new List<GameObject>();
    public List<GameObject> usableCards = new List<GameObject>();
    public bool[] flag;
    public Transform Suffer;
    private int index = 0;

    [Range(-10.0f,10.0f)]
    public float gapNumber = 5.0f;
    private void Start()
    {
        GetSuffer();
        flag = new bool[usableCards.Count];
        ResetAllFlags();
    }
    private void Update()
    {
        if (this.gameObject.tag == "PlayerBar")
        {
            if (Input.GetKey(KeyCode.C) && this.gameObject.transform.childCount >= 3 && PlayerStatus.playersuffer.Count < usableCards.Count)
                UseCard();
        }
        else if(this.gameObject.tag == "EnemyBar")
        {
            if (this.gameObject.transform.childCount >= 3 && EnemyStatus.enemysuffer.Count < usableCards.Count)
                UseCard();
        }
    }

    private void UseCard()
    {
        Destroy(this.gameObject.transform.GetChild(2).gameObject);
        Destroy(this.gameObject.transform.GetChild(1).gameObject);
        Destroy(this.gameObject.transform.GetChild(0).gameObject);
        // reduce 3 with 1 skill

        //Instantiate Card and Sample
        GameObject randomCard;
        while(true)
        {
            index = Random.Range(0, usableCards.Count - 1);
            if (this.gameObject.tag == "EnemyBar" && !flag[index]) 
            {
                flag[index] = true;
                break;
            }
            else if (this.gameObject.tag == "PlayerBar" && !flag[index])
            {
                flag[index] = true;
                break;
            }
        }
        
        randomCard = Instantiate(usableCards[index]) as GameObject;
        foreach (GameObject sample in usableCardsSamples)
        {
            if(usableCards[index].gameObject.name + "Example" == sample.name )
                Instantiate(sample);
        }
        GetSuffer();
        //KickCard(index);
        randomCard.transform.SetParent(Suffer);
        ReArrange();

        // Allocate to PlayerStatus or EnemyStatus
        if (this.gameObject.tag == "EnemyBar")
            PlayerStatus.addPlayerSkill(randomCard);
        else if (this.gameObject.tag == "PlayerBar")
            EnemyStatus.addEnemySkill(randomCard);
        
        //note
    }
    public void ReArrange()
    {
        for (int i = 0; i < Suffer.childCount; i++)
        {
            Suffer.GetChild(i).transform.position = new Vector3(0 + gapNumber * 2.5f, 0f, 0f);
        }

        for (int j = 0; j < Suffer.transform.childCount;j++)
        {
            Suffer.transform.GetChild(j).transform.position = new Vector3(Suffer.transform.position.x + gapNumber * j, Suffer.transform.position.y, 0f);
        }
    }
    private void KickCard(int index)
    {
        usableCards.RemoveAt(index);
    }
    private void GetSuffer()
    {
        if (this.gameObject.tag == "EnemyBar")
            Suffer = GameObject.Find("PlayerCardEffect").transform;
        else if (this.gameObject.tag == "PlayerBar")
            Suffer = GameObject.Find("EnemyCardEffect").transform;
    }
    public void ResetAllFlags()
    {
        for(int i = 0 ; i < usableCards.Count ; i++)
        {
            flag[i] = false;
        }
    }
    public void ResetSpecificFlag(string name)
    {
        int i = 0;
        foreach(GameObject card in usableCards)
        {
            if(card.name + "(Clone)" == name)
            {
                flag[i] = true;
                break;
            }
            i++;
        }
    }
    
}
