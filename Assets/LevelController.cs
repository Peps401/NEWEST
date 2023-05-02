using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public CharacterController characterController;
    public Countdown countdown;
    public HealthUiController healthUiController;
    public GameOverController gameOverController;
    public int maxTime = 120;
    public float timeDamagePerc = 0.3f;
    public int damageFromTime = 1;

    public int roomsDiscovered = 0;

    private List<RoomController> roomControllers;

    void Awake()
    {
        InitializeController();
    }

    void Update()
    {
        
    }

    void InitializeController()
    {
        roomsDiscovered = 1;
        RoomController[] roomControllers = GetComponentsInChildren<RoomController>();
        foreach(RoomController roomController in roomControllers){
            roomController.InitializeController(this);
        }
        countdown.InitializeController(this, maxTime);
        characterController.InitializeController(this, true);
        healthUiController.InitializeController(characterController.health);
        gameOverController.InitializeController();
    }

    public void UpdateHealth(int newValue)
    {
        //?
        healthUiController.SetHealth((float)newValue/characterController.maxHealth);
        if(newValue == 0){
            GameLost();
        }
    }

    public void NewRoomDiscovered(){
        roomsDiscovered++;
        Debug.Log(roomsDiscovered);
        if(roomsDiscovered>=6){
            //Spawn enemy
            countdown.AllRoomsDiscovered();
        }
    }

    public CharacterController GetCharacterController(){
        return characterController;
    }

    public void GameLost(){
        characterController.movementAllowed = false;
        gameOverController.Setup();
    }

}
