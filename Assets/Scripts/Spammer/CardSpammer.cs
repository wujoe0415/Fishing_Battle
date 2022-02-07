using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpammer : MonoBehaviour
{
    public GameObject card;
    public float minspamCycle = 1f;
    public float maxspamCycle = 5f;
    private float spamCycle;
    private float time = 0f;
    [Range(-9f,9f)]
    public float minX;
    [Range(-9f, 9f)]
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        spamCycle = (minspamCycle + maxspamCycle) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= spamCycle && this.gameObject.transform.childCount < 4)
        {
            Spam(card);
            time = 0;
            spamCycle = Random.Range(minspamCycle, maxspamCycle);
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void Spam(GameObject card)
    {
        Vector3 spamPosition = new Vector3(Random.Range(minX, maxX), -2.5f, 0);
        Instantiate(card, spamPosition , Quaternion.Euler(0,0,0), this.gameObject.transform);
    }
}
