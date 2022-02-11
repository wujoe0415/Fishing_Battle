using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerName : MonoBehaviour
{
    public string name;
    public string PlayerName { get { return name; }
                               set { name = value; }
    }

    private static GetPlayerName instance;
    private GetPlayerName() { }

    public static GetPlayerName Instance
    {
        get { return instance; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            return;
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //        Debug.Log(PlayerName);
    //}
    public void SetName(string endName)
    {
        name = endName;
    }
    public string GetName()
    {
        return name;
    }
}
