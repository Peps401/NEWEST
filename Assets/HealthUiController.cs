using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUiController : MonoBehaviour
{    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void InitializeController(int initHealth){
        slider.minValue = 0;
        slider.maxValue = 100;
        SetHealth(initHealth);
    }
    
    public void SetHealth(float newValue){
        if(newValue<0){
            newValue = 0;
        }
        if(newValue>100){
            newValue=100;
        }

        slider.value = newValue * (slider.maxValue-slider.minValue); 

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
