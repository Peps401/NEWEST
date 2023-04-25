using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelUiController levelUiController;
    public CharacterController characterController;
    private int timeLeft = 120;

    private float timePassed = 0.0f;

    void Awake(){
        characterController.levelController = this;
        levelUiController.RefreshTimer(timeLeft);
        UpdateHealth(characterController.health);
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 1.0f)
        {
            timeLeft--;
            timePassed = 0.0f;
            levelUiController.RefreshTimer(timeLeft);
        }
    }

    public void UpdateHealth(int newValue){
        levelUiController.SetHealth(newValue);
    }

}
