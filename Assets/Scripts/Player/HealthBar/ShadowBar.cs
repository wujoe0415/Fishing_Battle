using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowBar : MonoBehaviour
{
    public float currentHp;
    [Range(0f,10f)]
    public float decreaseTime;

    public Slider slide;
    public Gradient gradiant;
    public Image fill;

    IEnumerator decreaseHp;
    WaitForSeconds delaySeconds;

    public void SetMaxHealth(int health)
    {
        currentHp = health;
        slide.maxValue = health;
        slide.value = health;
        fill.color = gradiant.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        currentHp = health;
        slide.value = health;

        fill.color = gradiant.Evaluate(slide.normalizedValue);
    }
    public void DecreaseHp(int targetHp)
    {
        if (decreaseHp != null)
            StopCoroutine(decreaseHp);

        float decreaseAmount =  (currentHp - targetHp) / decreaseTime;
        delaySeconds = new WaitForSeconds(1 / decreaseAmount);
        decreaseHp = Decrease(targetHp, decreaseAmount);
        StartCoroutine(decreaseHp);

    }
    IEnumerator Decrease(int targetHp, float decreaseAmount)
    {
        for (float i = currentHp; i > targetHp; i -= decreaseAmount)
        {
            Debug.Log(currentHp);
            currentHp = i;
            slide.value = currentHp;
            fill.color = gradiant.Evaluate(slide.normalizedValue);

            yield return delaySeconds;
        }

        currentHp = targetHp;
        slide.value = currentHp;
        fill.color = gradiant.Evaluate(slide.normalizedValue);
    }

}
