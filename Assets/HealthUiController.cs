using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUiController : MonoBehaviour
{
    public TMP_Text healthText;
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int newValue){
        slider.maxValue = newValue;
        slider.value = newValue;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetHealth(int newValue){
        Debug.Log(newValue);
        healthText.text = newValue.ToString();
        //slider.value = newValue; 

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
