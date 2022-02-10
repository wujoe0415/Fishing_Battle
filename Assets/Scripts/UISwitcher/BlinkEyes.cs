using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEyes : MonoBehaviour
{
    List<GameObject> Eyes = new List<GameObject>();

    [Range(0f,5f)]
    public float cycle = 1f;
    [Range(0f, 5f)]
    public float litDuration = 0.2f;

    bool lit = false;
    WaitForSeconds Cycle;
    WaitForSeconds Lit;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Eyes.Add(gameObject.transform.GetChild(i).gameObject);
            Eyes[i].SetActive(false);
        }

        Cycle = new WaitForSeconds(cycle);
        Lit = new WaitForSeconds(litDuration);
        StartCoroutine(BlinkEye());
    }
    IEnumerator BlinkEye()
    {
        while(true)
        {
            if(lit)
            {
                yield return Lit;
                LitEyes();
                Debug.Log("lit");
                lit = false;
            }
            else
            {
                yield return Cycle;
                UnLitEyes();
                Debug.Log("unlit");
                lit = true;
            }
        }
    }
    void LitEyes()
    {
        foreach (GameObject eye in Eyes)
            eye.SetActive(true);
    }
    void UnLitEyes()
    {
        foreach (GameObject eye in Eyes)
            eye.SetActive(false);
    }

}
