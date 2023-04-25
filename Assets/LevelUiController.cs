using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUiController : MonoBehaviour
{
    public TimerUIController timerUIController;
    public HealthUiController healthUiController;

    public void RefreshTimer(int newValue){
        timerUIController.SetTimer(newValue);
    }

    public void SetHealth(int newValue){
        healthUiController.SetHealth(newValue);
    }
}
