using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkManual : MonoBehaviour
{
    [Range(0.1f,2f)]
    public float cycle = 1f;
    public Color initColor;
    public Color targetColor;
    public Text text;
    bool Fadeaway = true;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (initColor == null)
            initColor = GetComponent<Text>().color;
        StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        while (true)
        {
            if (Fadeaway)
            {
                for (float i = cycle; i >=0; i -= Time.deltaTime)
                {
                    text.color = Color.Lerp(initColor, targetColor, i / cycle);
                    yield return null;
                }
                Fadeaway = false;
            }
            else {
                for (float i = cycle; i >= 0; i -= Time.deltaTime)
                {
                    text.color = Color.Lerp(targetColor, initColor, i / cycle);
                    yield return null;
                }
                Fadeaway = true;
            }
        }
    }
}
