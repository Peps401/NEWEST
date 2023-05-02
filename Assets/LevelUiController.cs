using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUiController : MonoBehaviour
{
    private TimerUIController timerUIController;
    private HealthUiController healthUiController;
    private GameOverController gameOverController;

    public void InitializeController(int initTimer, int initHealth){
        timerUIController = GetComponentInChildren<TimerUIController>();
        healthUiController = GetComponentInChildren<HealthUiController>();
        gameOverController = GetComponentInChildren<GameOverController>();

        RefreshTimer(initTimer);
        healthUiController.InitializeController(initHealth);
        gameOverController.InitializeController();

        GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
    }

    public void RefreshTimer(int newValue){
        timerUIController.SetTimer(newValue);
    }

    public void SetHealth(float newValue){
        healthUiController.SetHealth(newValue);
    }

    public void StartGameOverScreen(){
        gameOverController.Setup();
    }
}
