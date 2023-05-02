using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool initialVisibility = false;

    private LevelController levelController;
    
    // Start is called before the first frame update
    public void InitializeController(LevelController levelController)
    {
        this.levelController = levelController;
        gameObject.SetActive(initialVisibility);
        DoorController[] doorControllers = GetComponentsInChildren<DoorController>();
        foreach (DoorController door in doorControllers)
        {
            door.roomController = this;
        }
    }

    public void Toggle(bool visible){
        if(gameObject.activeSelf == false){
            gameObject.SetActive(visible);
            levelController.NewRoomDiscovered();
        }
    }

    public bool IsActive(){
        return this.gameObject.activeSelf;
    }
}
