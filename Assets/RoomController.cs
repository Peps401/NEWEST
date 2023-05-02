using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool initialVisibility = false;

    public LevelController levelController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(initialVisibility);
        DoorController[] doorControllers = GetComponentsInChildren<DoorController>();
        foreach (DoorController door in doorControllers)
        {
            door.roomController = this;
        }
    }

    public void Toggle(bool visible){
        if(gameObject.activeSelf == false){
            int x = levelController.roomsDiscovered;
            levelController.roomsDiscovered += 1;
            Debug.Log("Rooms discovered" + x);
            gameObject.SetActive(visible);
        }

        if(levelController.roomsDiscovered == 6){
            GameObject.FindGameObjectWithTag("Enemy").SetActive(visible);
        }
    }
}
