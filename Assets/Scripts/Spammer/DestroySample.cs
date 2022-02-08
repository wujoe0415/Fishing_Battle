using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.005f)
        {
            spriteRender.color = new Color(1f,1f,1f,ft);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
