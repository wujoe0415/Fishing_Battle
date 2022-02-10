using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMe : MonoBehaviour
{
    private static DontDestroyMe instance;
    private DontDestroyMe() { }

    public static DontDestroyMe Instance {
        get { return instance; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != null)
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
}
