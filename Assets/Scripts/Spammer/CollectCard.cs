using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCard : MonoBehaviour
{
    public GameObject cardSprite;
    Transform PlayerCardCollector;
    Transform EnemyCardCollector;
    private int maxCollectCardNum = 4;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            PlayerCardCollector = GameObject.Find("PlayerCardCollector").GetComponent<Transform>();
            if (PlayerCardCollector.childCount < maxCollectCardNum)
            {
                GameObject cardReference = Instantiate(cardSprite) as GameObject;
                cardReference.gameObject.transform.SetParent(PlayerCardCollector);
                cardReference.gameObject.transform.position = new Vector3(-8f + 0.65f * PlayerCardCollector.childCount, 2.65f, 0);
                Destroy(this.gameObject);
            }
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            EnemyCardCollector = GameObject.Find("EnemyCardCollector").GetComponent<Transform>();
            if (EnemyCardCollector.childCount < maxCollectCardNum)
            {
                GameObject cardReference = Instantiate(cardSprite) as GameObject;
                cardReference.gameObject.transform.SetParent(EnemyCardCollector);
                cardReference.gameObject.transform.position = new Vector3(8f - 0.65f * EnemyCardCollector.childCount, 2.65f, 0);
                Destroy(this.gameObject);
            }
        }
    }
}
