using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpammer : MonoBehaviour
{
    public GameObject card;
    public float spamCycle = 5f;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= spamCycle && this.gameObject.transform.childCount < 4)
        {
            Spam(card);
            time = 0;
            spamCycle = Random.Range(4f, spamCycle);
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void Spam(GameObject card)
    {
        Vector3 spamPosition = new Vector3(Random.Range(-8.8f,9.11f), -2.5f, 0);
        Instantiate(card, spamPosition , Quaternion.Euler(0,0,0), this.gameObject.transform);
    }
}
