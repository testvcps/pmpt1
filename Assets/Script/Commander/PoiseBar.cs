using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoiseBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxPoise(int poise)
    {
        slider.maxValue = poise;
        slider.value = poise;
    }
    public void SetHealth(int poise)
    {
        slider.value = poise;
    }
}
