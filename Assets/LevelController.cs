using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public LevelUiController levelUiController;
    public CharacterController characterController;
    public Countdown countdown;
    public int maxTime = 120;
    public float timeDamagePerc = 0.3f;
    public int damageFromTime = 1;
    private int timeLeft;

    private float timePassed = 0.0f;

    public int roomsDiscovered = 1;

    void Awake()
    {
        InitializeController();
    }

    void Update()
    {
        /*timePassed += Time.deltaTime;
        if (timePassed >= 1.0f)
        {
            timeLeft--;
            timePassed = 0.0f;
            levelUiController.RefreshTimer(timeLeft);

            if(timeLeft/maxTime < timeDamagePerc){
                characterController.LoseHealth(damageFromTime);
            }
        }*/
        countdown.InitializeController(this, maxTime);  
    }

    void InitializeController()
    {
        timeLeft = maxTime;
        characterController.InitializeController(this, true);
        levelUiController.InitializeController(maxTime, characterController.health);
    }

    public void UpdateHealth(int newValue)
    {
        //?
        levelUiController.SetHealth(newValue/characterController.maxHealth);
        if(newValue == 0){
            levelUiController.StartGameOverScreen();
            characterController.movementAllowed = false;
        }
    }

}
