using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnew : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
            yield return null;
        }
        Debug.Log("exit for loop");
        yield return new WaitForSeconds(3);
        Debug.Log("wait 3 seconds");
    }
}
