using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingManual : MonoBehaviour
{
    public GameObject ManualImage;

    // Start is called before the first frame update
    void Start()
    {
        ManualImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
            ManualImage.SetActive(true);
        if (Input.GetKeyUp(KeyCode.M))
            ManualImage.SetActive(false);
    }
}
