using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlide : MonoBehaviour
{
    public Slider slide;
    public Gradient gradiant;
    public Image fill;
    // Start is called before the first frame update
   public void SetHealth(int health)
   {
        slide.value = health;

        fill.color = gradiant.Evaluate(slide.normalizedValue);
   }
    public void MaxSetHealth(int health)
    {
        slide.maxValue = health;
        slide.value = health;
        fill.color = gradiant.Evaluate(1f);
    }
}
